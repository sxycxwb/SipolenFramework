using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace RDIFramework.NET
{
    using RDIFramework.Controls;

    public partial class FrmRegexTester : Form
    {
        private const string STOPPED_MODE_BUTTON_TEXT = "Test [F5]";
        private const string RUNNING_MODE_BUTTON_TEXT = "Stop [Esc]";

        private Thread worker; // The worker that really does the execution in a separate thread.

        public FrmRegexTester()
        {
            InitializeComponent();
            ActiveControl = regExTextBox;
            textRichTextBox.HideToolstripItemsByGroup(
                RicherTextBoxToolStripGroups.Alignment |
                RicherTextBoxToolStripGroups.BoldUnderlineItalic,
                false);

            textRichTextBox.HideToolstripItemsByGroup(RicherTextBoxToolStripGroups.Alignment, true);
            textRichTextBox.HideToolstripItemsByGroup(RicherTextBoxToolStripGroups.BoldUnderlineItalic, true);

            textRichTextBox.ToggleBold();
            textRichTextBox.SetFontSize(8.25f);
        }

        private void FrmRegexTester_Load(object sender, EventArgs e)
        {
            // Writting some version information on screen
            this.Text += " - v" + Application.ProductVersion.ToString();
            //contextStatusBarPanel.Text = string.Format("CLR {0}.{1}", Environment.Version.Major, Environment.Version.Minor);

            // This is a critical line.
            // It allows the other thread to access the controls of this class/object.
            Control.CheckForIllegalCrossThreadCalls = false;

            // This sets the initial UI with Replace Mode Off
            replaceModeCheckBox.Checked = false;
        }

        private void FrmRegexTester_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5 && testButton.Text == STOPPED_MODE_BUTTON_TEXT && !e.Control && !e.Alt && !e.Shift)
            {
                StartTest();
            }
            else if (e.KeyCode == Keys.Escape && testButton.Text == RUNNING_MODE_BUTTON_TEXT && !e.Control && !e.Alt && !e.Shift)
            {
                AbortTest();
            }
        }

        private void testButton_Click(object sender, EventArgs e)
        {
            if (testButton.Text == STOPPED_MODE_BUTTON_TEXT)
            {
                StartTest();
            }
            else if (testButton.Text == RUNNING_MODE_BUTTON_TEXT)
            {
                AbortTest();
            }
        }

        #region Test/Evaluate Feature implementation

        /// <summary>
        /// Prepare and launch the asynchronous execution using another thread
        /// </summary>
        private void StartTest()
        {
            sbpStatus.Text = "Creating the Test Thread...";
            // Creates the separate Thread for executing the Test
            worker = new Thread(AsyncTest);

            // After this instruction if the worker hungs and this thread exits then nobody has to
            // wait for the worker to finish. (e.g. The worker will be aborted if the user wants to close the app.)
            worker.IsBackground = true;

            // Start the Asynchronous Test function
            worker.Start();
        }

        /// <summary>
        /// Instructs to abort the asynchronous execution of the Test.
        /// </summary>
        private void AbortTest()
        {
            // This generates a ThreadAbortException at the worker function AsyncTest()
            if (worker.IsAlive)
                worker.Abort();
        }

        /// <summary>
        /// This is the core of the app. The RegEx execution and processing function.
        /// It's being run on a separated thread.
        /// </summary>
        private void AsyncTest()
        {
            int rtbSelectionStart = int.MinValue;
            int rtbSelectionLength = int.MinValue;
            int matchesFound = 0;
            int matchesProcessed = 0;
            DateTime startMoment = DateTime.Now;

            // Every line in this function is susceptible of a ThreadAbortException
            // Which is how the user is able to stop it.
            try
            {
                // Adjustments in the UI
                sbpStatus.Text = "Making UI Adjustments...";
                testButton.Text = RUNNING_MODE_BUTTON_TEXT;
                sbpMatches.Text = string.Empty;
                sbpExecutionTime.Text = string.Empty;

                // Create the options object based on the UI checkboxes
                sbpStatus.Text = "Configuring the RegEx engine...";
                RegexOptions regexOptions = new RegexOptions();
                if (ignoreCaseCheckBox.Checked) regexOptions |= RegexOptions.IgnoreCase;
                if (cultureInvariantCheckBox.Checked) regexOptions |= RegexOptions.CultureInvariant;
                if (multiLineCheckBox.Checked) regexOptions |= RegexOptions.Multiline;
                if (singleLineCheckBox.Checked) regexOptions |= RegexOptions.Singleline;
                if (indentedInputCheckBox.Checked) regexOptions |= RegexOptions.IgnorePatternWhitespace;

                sbpStatus.Text = "Creating the RegEx Engine and parsing the RegEx string...";
                // Creates the RegEx engine passing the RegEx string and the options object
                Regex regex = new Regex(regExTextBox.Text, regexOptions);

                sbpStatus.Text = "Evaluating the RegEx against the Test Text...";
                // This executes the Regex and collects the results
                // The execution isn't done until a member of the matchCollection is read.
                // So I read the Count property for the regex to really execute from start to finish
                MatchCollection matchCollection = regex.Matches(textRichTextBox.Text);
                matchesFound = matchCollection.Count;
                
                // Also do the RegEx replacement if the user asked for it
                if (replaceModeCheckBox.Checked)
                {
                    sbpStatus.Text = "Evaluating the RegEx Replace against the Test Text...";
                    resultsRichTextBox.Text = regex.Replace(textRichTextBox.Text, repExTextBox.Text);
                }

                sbpStatus.Text = "Preparing the Results grid...";
                // Setup the results ListView
                resultListView.Items.Clear();
                for (int i = resultListView.Columns.Count; i > 3; i--) //Skip the first 3 columns
                    resultListView.Columns.RemoveAt(i - 1);

                // Add the Capture Group columns to the Results ListView
                int[] groupNumbers = regex.GetGroupNumbers();
                string[] groupNames = regex.GetGroupNames();
                string groupName = null;

                foreach (int groupNumber in groupNumbers)
                {
                    if (groupNumber > 0)
                    {
                        groupName = "Group " + groupNumber;
                        if (groupNames[groupNumber] != groupNumber.ToString()) groupName += " (" + groupNames[groupNumber] + ")";
                        resultListView.Columns.Add(groupName, 100, HorizontalAlignment.Left);
                    }
                }

                // Store/Backup the user's cursor and selection on the RichTextBox
                rtbSelectionStart = textRichTextBox.SelectionStart;
                rtbSelectionLength = textRichTextBox.SelectionLength;

                // This pauses the drawing to speed-up the work
                textRichTextBox.SuspendLayout();
                resultListView.SuspendLayout();
                resultListView.BeginUpdate();

                // Reset previous highligths in the RichTextBox and save current position.
                textRichTextBox.SelectAll();
                textRichTextBox.SelectionColor = Color.Black;

                sbpStatus.Text = "Processing the " + matchesFound + " matchs...";
                // Process each of the Matches!
                foreach (Match match in matchCollection)
                {
                    //Add it to the grid
                    ListViewItem lvi = resultListView.Items.Add(match.ToString());
                    lvi.SubItems.Add(match.Index.ToString());
                    lvi.SubItems.Add(match.Length.ToString());
                    for (int c = 1; c < match.Groups.Count; c++)
                    {
                        Group group = match.Groups[c];
                        if (group.Captures.Count == 1)
                            lvi.SubItems.Add(group.Value);
                        else
                        {
                            StringBuilder capturedValues = new StringBuilder();
                            foreach (Capture capture in group.Captures)
                            {
                                if (capturedValues.Length > 0)

                                    capturedValues.Append(" ?");
                                capturedValues.Append(capture.Value);
                            }
                            lvi.SubItems.Add(capturedValues.ToString());
                        }
                    }
                    
                    //Highligth the match in the RichTextBox
                    textRichTextBox.Select(match.Index, match.Length);
                    textRichTextBox.SelectionColor = Color.Red;

                    matchesProcessed++;
                }

                sbpStatus.Text = "Test success.";
            }
            catch (ThreadAbortException)
            {
                sbpStatus.Text = "Test aborted by the user.";
            }
            catch (Exception e)
            {
                sbpStatus.Text = "Test aborted by an error.";
                // Any other Exception is shown to the user
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Restore the btnText functionality
                testButton.Text = STOPPED_MODE_BUTTON_TEXT;

                // Restore RichTextBox's cursor position to the original user's position
                if (rtbSelectionStart != int.MinValue && rtbSelectionLength != int.MinValue)
                    textRichTextBox.Select(rtbSelectionStart, rtbSelectionLength);

                if (matchesProcessed == matchesFound)
                    sbpMatches.Text = string.Format("{0} match(es).", matchesProcessed);
                else
                    sbpMatches.Text = string.Format("{0} match(es) of {1} found.", matchesProcessed, matchesFound);


                // Calculate execution time
                TimeSpan executionTimeSpan = DateTime.Now.Subtract(startMoment);
                if (executionTimeSpan.TotalHours > 1) sbpExecutionTime.Text = string.Format("{0} hs.", executionTimeSpan.TotalHours.ToString("##.##"));
                else if (executionTimeSpan.TotalMinutes > 1) sbpExecutionTime.Text = string.Format("{0} mins.", executionTimeSpan.TotalMinutes.ToString("##.##"));
                else if (executionTimeSpan.TotalSeconds > 1) sbpExecutionTime.Text = string.Format("{0} s.", executionTimeSpan.TotalSeconds.ToString("##.##"));
                else if (executionTimeSpan.TotalMilliseconds > 1) sbpExecutionTime.Text = string.Format("{0} ms.", executionTimeSpan.TotalMilliseconds.ToString("#"));

                // This reverts the rendering of the controls (turned off for performance)
                resultListView.EndUpdate();
                resultListView.ResumeLayout();
                textRichTextBox.ResumeLayout();
            }
        }

        /// <summary>
        /// Show the matched text on the rtbText when the user clicks on a match in the ListView
        /// </summary>
        private void resultListView_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (resultListView.SelectedItems.Count == 0) return;

            textRichTextBox.Select(0, 0);

            int position = Convert.ToInt32(resultListView.SelectedItems[0].SubItems[1].Text);
            int length = Convert.ToInt32(resultListView.SelectedItems[0].SubItems[2].Text);

            textRichTextBox.Select(position, length);
        }

        #endregion

        private void indentedInputCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (indentedInputCheckBox.Checked)
            {
                regExTextBox.Multiline = repExTextBox.Multiline = true;
                regExTextBox.AcceptsTab = repExTextBox.AcceptsTab = true;
                regExTextBox.ScrollBars = repExTextBox.ScrollBars = ScrollBars.Vertical;

                topAndMiddleSplitContainer.IsSplitterFixed = false;
                topAndMiddleSplitContainer.SplitterDistance = 160;
            }
            else
            {
                regExTextBox.Multiline = repExTextBox.Multiline = false;
                regExTextBox.AcceptsTab = repExTextBox.AcceptsTab = false;
                regExTextBox.ScrollBars = repExTextBox.ScrollBars = ScrollBars.None;

                topAndMiddleSplitContainer.SplitterDistance = 100;
                topAndMiddleSplitContainer.IsSplitterFixed = true;
            }
        }

        private void replaceModeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (replaceModeCheckBox.Checked)
            {
                regExAndRepExSplitContainer.Panel2Collapsed = false;
                textAndResultsSplitContainer.Panel2Collapsed = false;
                regExCheatSheetButton.Visible = false;
                regExLibraryButton.Visible = false;                
            }
            else
            {
                regExAndRepExSplitContainer.Panel2Collapsed = true;
                textAndResultsSplitContainer.Panel2Collapsed = true;
                regExCheatSheetButton.Visible = true;
                regExLibraryButton.Visible = true;                
            }
        }

        #region Copy Feature implementation
        private void copyButton_Click(object sender, EventArgs e)
        {
            copyButtonContextMenu.Show(copyButton, new Point(0, copyButton.Height));
        }

        private void copyGeneric0MenuItem_Click(object sender, EventArgs e)
        {
            // Grab the original text
            string regex = regExTextBox.Text;

            // I used the Tag attribute of each MenuItem to now identify which was pressed
            string format = ((ToolStripMenuItem)sender).Tag.ToString();

            if (format == "html")
            {
                regex = System.Web.HttpUtility.HtmlEncode(regex);
            }
            else if (format.StartsWith("csharp"))
            {
                regex = string.Format("@\"{0}\"", regex.Replace("\"", "\"\"")); //change  my"quo\te  to  @"my""quo\te"

                if (format.EndsWith("snippet"))
                {
                    StringBuilder regexsb = new StringBuilder();
                    regexsb.Append("Regex regex = new Regex(");
                    if (indentedInputCheckBox.Checked && regex.Contains("\n"))
                    {
                        regexsb.Append("\r\n    ");
                        regexsb.Append(Regex.Replace(regex, @"\r?\n", "$0    ", RegexOptions.Singleline));
                    }
                    else
                        regexsb.Append(regex);

                    if (ignoreCaseCheckBox.Checked || multiLineCheckBox.Checked || singleLineCheckBox.Checked || cultureInvariantCheckBox.Checked || indentedInputCheckBox.Checked)
                    {
                        regexsb.Append(", ");
                        if (indentedInputCheckBox.Checked && regex.Contains("\n"))
                            regexsb.Append("\r\n    ");
                        if (ignoreCaseCheckBox.Checked) regexsb.Append("RegexOptions.IgnoreCase | ");
                        if (cultureInvariantCheckBox.Checked) regexsb.Append("RegexOptions.CultureInvariant | ");
                        if (multiLineCheckBox.Checked) regexsb.Append("RegexOptions.Multiline | ");
                        if (singleLineCheckBox.Checked) regexsb.Append("RegexOptions.Singleline | ");
                        if (indentedInputCheckBox.Checked) regexsb.Append("RegexOptions.IgnorePatternWhitespace | ");
                        regexsb.Remove(regexsb.Length - 3, 3);// 3 = len(" | ")
                    }
                    regexsb.AppendLine(");");
                    regexsb.AppendLine("MatchCollection matchCollection = regex.Matches( [Target_string] );");
                    regexsb.AppendLine("foreach (Match match in matchCollection)");
                    regexsb.AppendLine("{");
                    regexsb.AppendLine("    do some work;");
                    regexsb.AppendLine("}");

                    regex = regexsb.ToString();
                }
            }

            // Copy it to the clipboard. Clipboard.SetText fails if regex is ""
            if (!string.IsNullOrEmpty(regex)) Clipboard.SetText(regex);
        }
        #endregion

        private void exportResultsButton_Click(object sender, EventArgs e)
        {
            if (resultListView.Items.Count < 1)
            {
                MessageBox.Show("There are no results to export.", "Export failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                sbpStatus.Text = "Export failed.";
                return;
            }

            if (exportSaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StringBuilder sb = new StringBuilder();

                bool firstColumn = true;
                foreach (ColumnHeader columnHeader in resultListView.Columns)
                {
                    if (!firstColumn)
                        sb.Append(",");
                    sb.AppendFormat("\"{0}\"", columnHeader.Text);
                    firstColumn = false;
                }
                sb.AppendLine();

                foreach (ListViewItem listViewItem in resultListView.Items)
                {
                    firstColumn = true;
                    foreach (ListViewItem.ListViewSubItem listViewSubItem in listViewItem.SubItems)
                    {
                        if (!firstColumn)
                            sb.Append(",");
                        sb.AppendFormat("\"{0}\"", listViewSubItem.Text);
                        firstColumn = false;
                    }
                    sb.AppendLine();
                }

                File.WriteAllText(exportSaveFileDialog.FileName, sb.ToString());
                sbpStatus.Text = "Export saved.";
            }
        }

        private void ignoreCaseButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This option makes the RegEx case-insensitive which means that 'a' and 'A' are treated as the same letter.", "Ignore Case Option", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void multiLineButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This option makes ^ and $ match beginning and end of each line insted of the beginning and end of the whole text.", "Treat as Multi Line Option", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cultureInvariantButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("If you use the Ignore Case Option you should always keep in mind the Culture Invariant Option because (\"file\" == \"FILE\") is True for many cultures (e.g. en-US) but it's False on some of them (e.g. tr-TR Turkish). Turning On this option is generally safer.", "Culture Invariant Option", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void singleLineButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This option makes . match every character including newline.", "Treat as Single Line Option", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void indentedInputButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"If you activate this option the RegEx will be stripped of \r \n \t \v and spaces before execution. This allows you to write thouse ugly, long and cryptic RegEx in an indented and spaced fashion. The whitespace characters still works inside character classes.", "Indented Input Option", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void replaceModeButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"You will be able to test a RegEx replacement expression. Remember that $0 represents the match and $N represents the Nth capture group.", "RegEx Replace Option", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void regExLibraryButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This would open the uri http://regexlib.com/ in your default browser.", "RegEx Library", MessageBoxButtons.OKCancel) == DialogResult.OK)
                Process.Start("http://regexlib.com/");
        }

        private void regExCheatSheetButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This would open the uri http://www.addedbytes.com/cheat-sheets/regular-expressions-cheat-sheet/ in your default browser.", "RegEx CheatSheet", MessageBoxButtons.OKCancel) == DialogResult.OK)
                Process.Start("http://www.addedbytes.com/cheat-sheets/regular-expressions-cheat-sheet/");
        }
    }
}

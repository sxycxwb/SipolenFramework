using System;
using System.Timers;

namespace RDIFramework.Utilities
{
    /// <summary>
    /// 包含一组方法和属性，提供简易的定时器应用。
    /// </summary>
    /// <typeparam name="T">表示与此类关联的对象的类型。</typeparam>
    public sealed class SimpleTimerProvider<T>
    {
        #region 私有字段

        private Action<T> _action1;
        private Action<T, ElapsedEventArgs> _action2;
        private Action<T, Timer> _action3;
        private Action<T, Timer, ElapsedEventArgs> _action4;

        #endregion

        #region 公有属性

        /// <summary>
        /// 获取与此类关联的对象的实例。
        /// </summary>
        public T Object { get; private set; }

        /// <summary>
        /// 获取用于生成定期事件的定时器的实例。
        /// </summary>
        public Timer Timer { get; private set; }

        #endregion

        #region 构造函数

        /// <summary>
        /// 初始化 <see cref="SimpleTimerProviderProvider{T}"/> 类的新实例。
        /// </summary>
        /// <param name="obj">指定与此类关联的对象的实例。</param>
        /// <param name="interval">指定引发事件的间隔时间（以毫秒为单位）。默认为 100 毫秒。</param>
        /// <param name="autoReset">如果应在每次间隔结束时引发事件，则为 true；如果它仅在间隔第一次结束后引发一次事件，则为 false。默认值为 true。</param>
        public SimpleTimerProvider(T obj, double interval, bool autoReset)
        {
            this.Object = obj;

            if (interval <= 0)
                interval = 100;

            this.Timer = new Timer
            {
                AutoReset = autoReset,
                Interval = interval
            };
        }

        /// <summary>
        /// 初始化 <see cref="SimpleTimerProviderProvider{T}"/> 类的新实例。
        /// </summary>
        /// <param name="obj">指定与此类关联的对象的实例。</param>
        /// <param name="interval">指定引发事件的间隔时间（以毫秒为单位）。默认为 100 毫秒。</param>
        public SimpleTimerProvider(T obj, double interval)
            : this(obj, interval, true)
        { }

        #endregion

        #region 私有方法

        private void _TimerElapsed1(object sender, ElapsedEventArgs e)
        {
            this._action1.Invoke(this.Object);
        }

        private void _TimerElapsed2(object sender, ElapsedEventArgs e)
        {
            this._action2.Invoke(this.Object, e);
        }

        private void _TimerElapsed3(object sender, ElapsedEventArgs e)
        {
            this._action3.Invoke(this.Object, this.Timer);
        }

        private void _TimerElapsed4(object sender, ElapsedEventArgs e)
        {
            this._action4.Invoke(this.Object, this.Timer, e);
        }

        #endregion

        #region 公有方法

        /// <summary>
        /// 执行定时器上的 <see cref="Action&lt;T&gt;"/> 委托方法。
        /// </summary>
        /// <param name="action">指定一个 <see cref="Action&lt;T&gt;"/> 委托。</param>
        public void Run(Action<T> action)
        {
            if (action == null)
                throw new ArgumentNullException("action");

            this._action1 = action;

            this.Timer.Elapsed += this._TimerElapsed1;
            this.Timer.Start();
        }

        /// <summary>
        /// 执行定时器上的 <see cref="Action&lt;T, ElapsedEventArgs&gt;"/> 委托方法。
        /// </summary>
        /// <param name="action">指定一个 <see cref="Action&lt;T, ElapsedEventArgs&gt;"/> 委托。</param>
        public void Run(Action<T, ElapsedEventArgs> action)
        {
            if (action == null)
                throw new ArgumentNullException("action");

            this._action2 = action;

            this.Timer.Elapsed += this._TimerElapsed2;
            this.Timer.Start();
        }

        /// <summary>
        /// 执行定时器上的 <see cref="Action&lt;T, Timer&gt;"/> 委托方法。
        /// </summary>
        /// <param name="action">指定一个 <see cref="Action&lt;T, Timer&gt;"/> 委托。</param>
        public void Run(Action<T, Timer> action)
        {
            if (action == null)
                throw new ArgumentNullException("action");

            this._action3 = action;

            this.Timer.Elapsed += this._TimerElapsed3;
            this.Timer.Start();
        }

        /// <summary>
        /// 执行定时器上的 <see cref="Action&lt;T, Timer, ElapsedEventArgs&gt;"/> 委托方法。
        /// </summary>
        /// <param name="action">指定一个 <see cref="Action&lt;T, Timer, ElapsedEventArgs&gt;"/> 委托。</param>
        public void Run(Action<T, Timer, ElapsedEventArgs> action)
        {
            if (action == null)
                throw new ArgumentNullException("action");

            this._action4 = action;

            this.Timer.Elapsed += this._TimerElapsed4;
            this.Timer.Start();
        }

        /// <summary>
        /// 关闭定时器并释放由 <see cref="SimpleTimerProviderProvider{T}"/> 占用的资源。
        /// </summary>
        public void Close()
        {
            this.Timer.Stop();
            this.Timer.Close();
        }

        #endregion
    }
}
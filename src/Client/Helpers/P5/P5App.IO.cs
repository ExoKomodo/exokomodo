namespace Client.Helpers.P5
{
    public abstract partial class P5App
    {
        #region Public

        #region Members
        public float Millis => _jsRuntime.Invoke<float>(
            _p5InvokeFunctionAndReturn,
            "millis"
        );
        #endregion

        #endregion
    }
}

namespace Task.Core.Result
{
    public class ResultO<TValue> : ResultO
    {
        private readonly TValue? value;
        protected internal ResultO(TValue? value, bool isSucess, Error error)
            : base(isSucess, error) => this.value = value;

        public TValue Value => IsSuccess
            ? value!
            : throw new InvalidOperationException("Error ");
        public static implicit operator ResultO<TValue>(TValue? value) => Create(value);

        public static implicit operator ResultO<TValue>(Error error) => Failure<TValue>(error);



    }
}

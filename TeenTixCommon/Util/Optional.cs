using System;

namespace TeenTix.Common.Util
{
	public class Optional<T>
	{
		private T value { get; set; }

		private Optional () {
			this.value = default(T);
		}

		private Optional (T value) {
			this.value = value;
		}

		public bool isPresent() {
			return value != null;
		}

		public T get() {
			return value;
		}

		public static Optional<T> of(T value) {
			if (value == null) {
				throw new InvalidOperationException ("value must not be null");
			}
			return ofNullable (value);
		}

		public static Optional<T> ofNullable(T value) {
			return new Optional<T> (value);
		}

		public static Optional<T> empty() {
			return new Optional<T> ();
		}

		public override string ToString ()
		{
			return string.Format ("[Optional: value={0}]", value);
		}
	}
}


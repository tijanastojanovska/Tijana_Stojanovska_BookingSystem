namespace BookingSystem.Business.Helpers
{

	/// <summary>
	/// Provides a helper for generating random alphanumeric booking codes
	/// </summary>
	public static class BookingCodeGenerator
	{
		private static readonly char[] _allowedCharacters = BuildAllowedCharacters();

		/// <summary>
		/// Generates a random booking code of the specified length
		/// </summary>
		public static string Generate(int length = 6)
		{
			if (length <= 0)
			{
				throw new ArgumentException("Length must be greater than 0");
			}

			char[] code = new char[length];

			for (int i = 0; i < length; i++)
			{
				int index = Random.Shared.Next(_allowedCharacters.Length);
				code[i] = _allowedCharacters[index];
			}

			return new string(code);
		}

		/// <summary>
		/// Builds the array of allowed characters for code generation
		/// </summary>
		private static char[] BuildAllowedCharacters()
		{
			List<char> characters = new List<char>();

			for (char c = '0'; c <= '9'; c++)
			{
				characters.Add(c);
			}

			for (char c = 'a'; c <= 'z'; c++)
			{
				characters.Add(c);
			}

			for (char c = 'A'; c <= 'Z'; c++)
			{
				characters.Add(c);
			}

			return characters.ToArray();
		}
	}
}

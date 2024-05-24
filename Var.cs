/// <summary>
/// This is the simplest form of expression. It holds the actual string value.
/// </summary>
class Var : Expression
{
    private string _value;

    /// <summary>
    /// Constructor for the VAR expression class.
    /// Every 'VAR' expression contains a string as its value.
    /// </summary>
    /// <param name="value">The string value of simple filter expression.</param>
    public Var(string value) : base(null, null) {
        this._value = value;
    }

    /// <summary>
    /// Calculates the VAR expression.
    /// This function returns a set of all the indexes of sentences that passed the simple filter condition.
    /// </summary>
    /// <param name="sentences_dictionary">The data. Contains for each word, what sentences have this word in them.</param>
    /// <returns>A set of all the indexes of sentences that passed the simple filter condition.</returns>
    public override HashSet<int> calculate(Dictionary<string, HashSet<int>> sentences_dictionary) {
        if(!sentences_dictionary.ContainsKey(this._value)) {
            return new HashSet<int>();
        }

        return new HashSet<int>(sentences_dictionary[this._value]);
    }
}
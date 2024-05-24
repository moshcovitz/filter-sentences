/// <summary>
/// This class is the superclass for expressions like AND, OR, and VAR.
/// Each expression can consist of two other sub-expressions.
/// </summary>
abstract class Expression
{
    protected Expression? _left_expression;
    protected Expression? _right_expression;


    /// <summary>
    /// Constructor for the expression abstract class.
    /// Every expression can be made out of two other expressions. 'exp1 and exp2'.
    /// </summary>
    /// <param name="left_expression">The left expression. e1 && e2 => this is e1</param>
    /// <param name="right_expression">The right expression. e1 && e2 => this is e2</param>
    public Expression(Expression? left_expression, Expression? right_expression) {
        _left_expression = left_expression;
        _right_expression = right_expression;
    }

    /// <summary>
    /// This function returns a set of all the indexes of sentences that passed the filter condition.
    /// </summary>
    /// <param name="sentences_dictionary">The data. Contains for each word, what sentences have this word in them.</param>
    /// <returns>A set of all the indexes of sentences that passed the filter condition</returns>
    public abstract HashSet<int> calculate(Dictionary<string, HashSet<int>> sentences_dictionary);
}
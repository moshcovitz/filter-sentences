/// <summary>
/// This is the main class that holds the data and invokes the calculation for the filtered sentences.
/// </summary>
class Filter
{
    private string[] _sentences;
    private int _num_of_sentences;
    private Dictionary<string, HashSet<int>> _sentences_dictionary;

    /// <summary>
    /// Constructor for the Filter class.
    /// Creates the data structure from an array of strings.
    /// </summary>
    /// <param name="sentences">An array of sentences</param>
    public Filter(string[] sentences) {
        this._sentences = sentences;
        this._num_of_sentences = _sentences.Length;
        _sentences_dictionary = new Dictionary<string, HashSet<int>>();
        Preprocess();
    }

    /// <summary>
    /// Handles all the preprocessing of the data such as removing duplicates and loading it to the data structure.
    /// </summary>
    private void Preprocess() {
        Remove_Duplicates();
        Load_Word_Dict();
    }

    /// <summary>
    /// This function make should to save "_sentences" but remove all duplicates.
    /// </summary>
    private void Remove_Duplicates() {
        Dictionary<string, bool> uniqueDict = new Dictionary<string, bool>();
        List<string> uniqueList = new List<string>();
        foreach (string str in this._sentences)
        {
            if (!uniqueDict.ContainsKey(str))
            {
                uniqueDict[str] = true;
                uniqueList.Add(str);
            }
        }
        this._sentences = uniqueList.ToArray();
        this._num_of_sentences = _sentences.Length;
    }

    /// <summary>
    /// Fills the data structure with data (words as keys and sets as values) from the sentences array.
    /// </summary>
    private void Load_Word_Dict() {
        for(int i = 0; i < _num_of_sentences; i++) {
            string sentence = _sentences[i];
            string[] filtered_words = sentence.Split();
            foreach(string word in filtered_words) {
                if(_sentences_dictionary.ContainsKey(word)) {
                        _sentences_dictionary[word].Add(i);
                } else {
                    HashSet<int> sentences_in_map = new HashSet<int>();
                    sentences_in_map.Add(i);
                    _sentences_dictionary.Add(word, sentences_in_map);
                }
            }
        }
    }

    /// <summary>
    /// Invokes the calculations and makes a list with all the filtered sentences.
    /// </summary>
    /// <param name="e">The filter expression</param>
    /// <returns>A list of all filtered sentences.</returns>
    public List<string> Get_Filtered_Sentences(Expression e) {
        List<string> filtered_sentences = new List<string>();
        HashSet<int> filtered_sentences_indexs = e.calculate(_sentences_dictionary);
        foreach(int index in filtered_sentences_indexs) {
            filtered_sentences.Add(_sentences[index]);
        }
        return filtered_sentences;
    }

}
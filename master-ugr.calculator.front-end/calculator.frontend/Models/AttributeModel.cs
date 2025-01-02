namespace calculator.frontend.Models
{
    public class AttributeModel
    {
        string is_prime = "";
        string is_odd = "";

        public void SetPrime(bool prime)
        {
            is_prime = prime ? "Yes" : "No";
        }

        public void SetOdd(bool odd)
        {
            is_odd = odd ? "Yes" : "No";
        }

        public string IsPrime()
        {
            return is_prime;
        }

        public string IsOdd()
        {
            return is_odd;
        }
    }
}

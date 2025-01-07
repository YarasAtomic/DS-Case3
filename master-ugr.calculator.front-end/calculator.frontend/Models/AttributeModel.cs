namespace calculator.frontend.Models
{
    public class AttributeModel
    {
        string is_prime = "";
        string is_odd = "";
        string sqrt = "";

        public void SetPrime(bool prime)
        {
            is_prime = prime ? "Yes" : "No";
        }

        public void SetOdd(bool odd)
        {
            is_odd = odd ? "Yes" : "No";
        }

        public void SetSqrt(double sqrt)
        {
            this.sqrt = sqrt.ToString();
        }

        public string IsPrime()
        {
            return is_prime;
        }

        public string IsOdd()
        {
            return is_odd;
        }

        public string Sqrt()
        {
            return sqrt;
        }
    }
}

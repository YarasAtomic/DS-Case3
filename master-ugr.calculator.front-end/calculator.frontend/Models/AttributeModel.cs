namespace calculator.frontend.Models
{
    public class AttributeModel
    {
        string is_prime = "";
        string is_odd = "";
        string sqrt = "";

        private static string BoolToString(bool value)
        {
            return value ? "Yes" : "No";
        }

        public void SetPrime(bool prime)
        {
            is_prime = BoolToString(prime);
        }

        public void SetOdd(bool odd)
        {
            is_odd = BoolToString(odd);
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

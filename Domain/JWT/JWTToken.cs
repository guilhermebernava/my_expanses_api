namespace Domain.JWT
{
	public class JWTToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }

        public JWTToken()
        {

        }
    }

}


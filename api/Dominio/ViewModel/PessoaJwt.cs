namespace api.Dominio.ViewModel
{
    public record PessoaJwt
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Token { get; set; }
        
    }
}
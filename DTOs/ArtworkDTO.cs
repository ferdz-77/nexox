namespace Nexox.DTOs
{
    public class ArtworkDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int AnoCriacao { get; set; }
        public string Tecnica { get; set; }
        public decimal Largura { get; set; }
        public decimal Altura { get; set; }
        public string Material { get; set; }
        public decimal? Preco { get; set; }
        public string Imagem { get; set; }
        public string Descricao { get; set; }
        public bool Status { get; set; } = true;
        public string Localizacao { get; set; }
        public string Proprietario { get; set; }
        public string Exposicao { get; set; }
        public int ArtistaId { get; set; } = 1;
    }
}

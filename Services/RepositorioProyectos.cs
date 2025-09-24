using portafolio.Models;
namespace portafolio.Services{
    public interface IRepositorioProyectos{
        List<ProyectoDTO> obtenerProyectos();
    }
    public class RepositorioProyectos : IRepositorioProyectos{
        public List<ProyectoDTO> obtenerProyectos(){
        return new List<ProyectoDTO>(){
            new ProyectoDTO(){
                Titulo = "Besties",
                Descripcion = "Juego de rol de acción",
                Link = "https://noswarstudios.com/",
                ImagenURL = "/Images/icon.png"
            },
            new ProyectoDTO(){
                Titulo = "Cosmic Wonderer",
                Descripcion = "Juego de plataforma sidescroller",
                Link = "https://noswarstudios.com/games",
                ImagenURL = "/Images/icon.png"
            },
            new ProyectoDTO(){
                Titulo = "Chambix",
                Descripcion = "Juego estrategia financiera",
                Link = "https://beta-hub.com/es/chambix",
                ImagenURL = "/Images/icon.png"
            }
        };
    }
    }
}
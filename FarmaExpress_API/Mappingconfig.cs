using AutoMapper;
using FarmaExpress.Models;
using FarmaExpress_API.Dto;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

namespace FarmaExpress_API
{
    public class Mappingconfig : Profile
    {
        public Mappingconfig()
        {
            CreateMap<Categoria, CategoriaDto>().ReverseMap();
            CreateMap<Producto, ProductoDto>().ReverseMap();     
            CreateMap<Pedido, PedidoCreateDto>().ReverseMap();
            CreateMap<Pedido, PedidoDto>().ReverseMap();
            CreateMap<Pedido, PedidoUpdateDto>().ReverseMap();   
            CreateMap<Usuario, UsuarioDto>().ReverseMap();
            CreateMap<Usuario, UsuarioCreateDto>().ReverseMap();
            CreateMap<Usuario, UsuarioUpdateDto>().ReverseMap();
        }
    }
}

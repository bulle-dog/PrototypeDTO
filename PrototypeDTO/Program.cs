using System;
using AutoMapper;

namespace PrototypeDTO
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<Product, ProductDTO.Request.Public>()
            );

            var mapper = new Mapper(config);
            //PersonDTO prDTO = Mapper.Map(pr, new PersonDTO());  

            Product product = new Product(){
                Id = "fdsfsd",
                Name = "Ordinateur",
                InternalNotes = "Notes diverses",
                Price = 10
            };

            ProductDTO.Request.Public request = mapper.Map<ProductDTO.Request.Public>(product);
            Console.WriteLine(request.Id + " - " + request.Name);
            Console.ReadKey();

            Console.WriteLine("Hello World!");
        }
    }

    public class Product{
        public string Id{ get;set;}

        public string Name { get;set;}

        public decimal Price { get;set;}

        public string InternalNotes{ get;set;}
    }

    /// <summary>
    /// This class is a DTO collection for Product class
    /// We declare each Product properties as an interface
    /// and we declare two structs: Request and Result, that represent request DTO and result DTO for each DTO.
    /// In this properties, we declare all DTO, that implement the ProductDTO properties interfaces.
    /// The intergaces help us to know what properties are available.
    /// </summary>
    public class ProductDTO{ 
        public ProductDTO(){
            Config = new MapperConfiguration(cfg =>
                cfg.CreateMap<Product, ProductDTO.Request.Public>()
            );
        }

        private readonly MapperConfiguration Config;
        private interface Id{
            public string Id{ get;set;}
        }

        private interface Name{
            public string Name{ get;set;}
        }

        private interface Price{
            public decimal Price{ get;set;}
        }

        private interface InternalNotes{
            public string InternalNotes{ get;set;}
        }
        public struct Request{
            public struct Public : Id,Name,Price{
                public string Id{get;set;}
                public string Name{get;set;}
                public decimal Price{get;set;}
            }

            public struct Private{
                public string Id;
                public string Name;
                public decimal Price;
                public string InternalNote;
            }
        };
        public struct Result{
            public struct Public
            {
                public string Id;
                public string Name;
                public decimal Price;
            }

            public struct Private
            {
                public string Id;
                public string Name;
                public decimal Price;
                public string InternalNote;
            }
        };
    }
}

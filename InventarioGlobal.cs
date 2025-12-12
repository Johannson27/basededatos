using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using redmax;

namespace redmax
{
    public static class InventarioGlobal
    {
        public static DataSet1.ClienteDataTable tablaCliente = new DataSet1.ClienteDataTable();
        public static DataSet1.CategoriaDataTable tablaCategoria = new DataSet1.CategoriaDataTable();
        public static DataSet1.ProductoDataTable tablaProductos = new DataSet1.ProductoDataTable();
    
    public static void LlenarCategorias()
        {
            tablaCategoria.Clear();

            var fila = tablaCategoria.NewCategoriaRow();
            fila.codigo = 1;
            fila.nombre = "Teléfonos";
            tablaCategoria.AddCategoriaRow(fila);

            fila = tablaCategoria.NewCategoriaRow();
            fila.codigo = 2;
            fila.nombre = "Laptops";
            tablaCategoria.AddCategoriaRow(fila);

            fila = tablaCategoria.NewCategoriaRow();
            fila.codigo = 3;
            fila.nombre = "Televisores";
            tablaCategoria.AddCategoriaRow(fila);

            fila = tablaCategoria.NewCategoriaRow();
            fila.codigo = 4;
            fila.nombre = "Cámaras";
            tablaCategoria.AddCategoriaRow(fila);

            fila = tablaCategoria.NewCategoriaRow();
            fila.codigo = 5;
            fila.nombre = "Consolas";
            tablaCategoria.AddCategoriaRow(fila);

            fila = tablaCategoria.NewCategoriaRow();
            fila.codigo = 6;
            fila.nombre = "Tablets";
            tablaCategoria.AddCategoriaRow(fila);

            fila = tablaCategoria.NewCategoriaRow();
            fila.codigo = 7;
            fila.nombre = "Smartwatches";
            tablaCategoria.AddCategoriaRow(fila);

            fila = tablaCategoria.NewCategoriaRow();
            fila.codigo = 8;
            fila.nombre = "Auriculares";
            tablaCategoria.AddCategoriaRow(fila);

            fila = tablaCategoria.NewCategoriaRow();
            fila.codigo = 9;
            fila.nombre = "Impresoras";
            tablaCategoria.AddCategoriaRow(fila);

            fila = tablaCategoria.NewCategoriaRow();
            fila.codigo = 10;
            fila.nombre = "Proyectores";
            tablaCategoria.AddCategoriaRow(fila);

            tablaCategoria.AcceptChanges();
        }

        public static void LlenarProductos()
        {
            tablaProductos.Clear();

            var fila = tablaProductos.NewProductoRow();
            fila.codigo = 1;
            fila.nombreproducto = "iPhone 15 Pro";
            fila.codigocategoria = 1;
            fila.stock = 15;
            fila.precio = 1199.99m;
            tablaProductos.AddProductoRow(fila);

            fila = tablaProductos.NewProductoRow();
            fila.codigo = 2;
            fila.nombreproducto = "MacBook Air M2";
            fila.codigocategoria = 2;
            fila.stock = 10;
            fila.precio = 999.99m;
            tablaProductos.AddProductoRow(fila);

            fila = tablaProductos.NewProductoRow();
            fila.codigo = 3;
            fila.nombreproducto = "Samsung QLED 4K";
            fila.codigocategoria = 3;
            fila.stock = 7;
            fila.precio = 799.99m;
            tablaProductos.AddProductoRow(fila);

            fila = tablaProductos.NewProductoRow();
            fila.codigo = 4;
            fila.nombreproducto = "Canon EOS M50";
            fila.codigocategoria = 4;
            fila.stock = 8;
            fila.precio = 649.50m;
            tablaProductos.AddProductoRow(fila);

            fila = tablaProductos.NewProductoRow();
            fila.codigo = 5;
            fila.nombreproducto = "Xbox Series X";
            fila.codigocategoria = 5;
            fila.stock = 5;
            fila.precio = 499.99m;
            tablaProductos.AddProductoRow(fila);

            fila = tablaProductos.NewProductoRow();
            fila.codigo = 6;
            fila.nombreproducto = "Samsung Galaxy Tab S9";
            fila.codigocategoria = 6;
            fila.stock = 12;
            fila.precio = 699.00m;
            tablaProductos.AddProductoRow(fila);

            fila = tablaProductos.NewProductoRow();
            fila.codigo = 7;
            fila.nombreproducto = "Huawei Watch GT 4";
            fila.codigocategoria = 7;
            fila.stock = 9;
            fila.precio = 249.00m;
            tablaProductos.AddProductoRow(fila);

            fila = tablaProductos.NewProductoRow();
            fila.codigo = 8;
            fila.nombreproducto = "Sony WH-1000XM4";
            fila.codigocategoria = 8;
            fila.stock = 14;
            fila.precio = 299.99m;
            tablaProductos.AddProductoRow(fila);

            fila = tablaProductos.NewProductoRow();
            fila.codigo = 9;
            fila.nombreproducto = "Epson EcoTank L3250";
            fila.codigocategoria = 9;
            fila.stock = 6;
            fila.precio = 199.99m;
            tablaProductos.AddProductoRow(fila);

            fila = tablaProductos.NewProductoRow();
            fila.codigo = 10;
            fila.nombreproducto = "BenQ TH585";
            fila.codigocategoria = 10;
            fila.stock = 4;
            fila.precio = 549.99m;
            tablaProductos.AddProductoRow(fila);

            tablaProductos.AcceptChanges();
        }
        static public void llenarClientes()
        {
            DataSet1.ClienteRow fila;

            fila = InventarioGlobal.tablaCliente.NewClienteRow();
            fila.codigo = 1;
            fila.nombre = "Luis";
            fila.apellido = "García";
            fila.nrc = "NR001";
            fila.ncedula = "001-010101-0000A";
            fila.fechaNacimiento = new DateTime(1990, 1, 1);
            fila.direccion = "Managua";
            fila.departamento = "MANAGUA";
            InventarioGlobal.tablaCliente.AddClienteRow(fila);

            fila = InventarioGlobal.tablaCliente.NewClienteRow();
            fila.codigo = 2;
            fila.nombre = "Salef";
            fila.apellido = "López";
            fila.nrc = "NR002";
            fila.ncedula = "002-020202-0001B";
            fila.fechaNacimiento = new DateTime(1985, 5, 12);
            fila.direccion = "León";
            fila.departamento = "LEON";
            InventarioGlobal.tablaCliente.AddClienteRow(fila);

            fila = InventarioGlobal.tablaCliente.NewClienteRow();
            fila.codigo = 3;
            fila.nombre = "Carlos";
            fila.apellido = "Martínez";
            fila.nrc = "NR003";
            fila.ncedula = "003-030303-0002C";
            fila.fechaNacimiento = new DateTime(1992, 3, 10);
            fila.direccion = "Masaya";
            fila.departamento = "MASAYA";
            InventarioGlobal.tablaCliente.AddClienteRow(fila);

            fila = InventarioGlobal.tablaCliente.NewClienteRow();
            fila.codigo = 4;
            fila.nombre = "Ana";
            fila.apellido = "Gómez";
            fila.nrc = "NR004";
            fila.ncedula = "004-040404-0003D";
            fila.fechaNacimiento = new DateTime(1995, 7, 20);
            fila.direccion = "Boaco";
            fila.departamento = "BOACO";
            InventarioGlobal.tablaCliente.AddClienteRow(fila);

            fila = InventarioGlobal.tablaCliente.NewClienteRow();
            fila.codigo = 5;
            fila.nombre = "Jorge";
            fila.apellido = "Ramírez";
            fila.nrc = "NR005";
            fila.ncedula = "005-050505-0004E";
            fila.fechaNacimiento = new DateTime(1988, 9, 15);
            fila.direccion = "Chontales";
            fila.departamento = "CHONTALES";
            InventarioGlobal.tablaCliente.AddClienteRow(fila);

            fila = InventarioGlobal.tablaCliente.NewClienteRow();
            fila.codigo = 6;
            fila.nombre = "Sofía";
            fila.apellido = "Vargas";
            fila.nrc = "NR006";
            fila.ncedula = "006-060606-0005F";
            fila.fechaNacimiento = new DateTime(2000, 11, 5);
            fila.direccion = "Matagalpa";
            fila.departamento = "MATAGALPA";
            InventarioGlobal.tablaCliente.AddClienteRow(fila);

            fila = InventarioGlobal.tablaCliente.NewClienteRow();
            fila.codigo = 7;
            fila.nombre = "Miguel";
            fila.apellido = "Pérez";
            fila.nrc = "NR007";
            fila.ncedula = "007-070707-0006G";
            fila.fechaNacimiento = new DateTime(1982, 4, 8);
            fila.direccion = "Rivas";
            fila.departamento = "RIVAS";
            InventarioGlobal.tablaCliente.AddClienteRow(fila);

            fila = InventarioGlobal.tablaCliente.NewClienteRow();
            fila.codigo = 8;
            fila.nombre = "Lucía";
            fila.apellido = "Hernández";
            fila.nrc = "NR008";
            fila.ncedula = "008-080808-0007H";
            fila.fechaNacimiento = new DateTime(1999, 2, 28);
            fila.direccion = "Estelí";
            fila.departamento = "ESTELI";
            InventarioGlobal.tablaCliente.AddClienteRow(fila);

            fila = InventarioGlobal.tablaCliente.NewClienteRow();
            fila.codigo = 9;
            fila.nombre = "Diego";
            fila.apellido = "Cruz";
            fila.nrc = "NR009";
            fila.ncedula = "009-090909-0008I";
            fila.fechaNacimiento = new DateTime(1993, 6, 18);
            fila.direccion = "Chinandega";
            fila.departamento = "CHINANDEGA";
            InventarioGlobal.tablaCliente.AddClienteRow(fila);

            fila = InventarioGlobal.tablaCliente.NewClienteRow();
            fila.codigo = 10;
            fila.nombre = "Valeria";
            fila.apellido = "Morales";
            fila.nrc = "NR010";
            fila.ncedula = "010-101010-0009J";
            fila.fechaNacimiento = new DateTime(1991, 10, 10);
            fila.direccion = "Jinotega";
            fila.departamento = "JINOTEGA";
            InventarioGlobal.tablaCliente.AddClienteRow(fila);

            InventarioGlobal.tablaCliente.AcceptChanges();
        }
    }
}


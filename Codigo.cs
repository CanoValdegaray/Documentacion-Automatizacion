using OpenQA.Selenium;
using System.Diagnostics;
using OpenQA.Selenium.Edge;
using System;


namespace Selenium
{
    public class Test : IDisposable
    {
        private IWebDriver driver;

        public Test()
        {
            var options = new EdgeOptions();
            // options.AddArgument("--headless");
            options.AddArgument("--disable-popup-blocking");
            options.AddArgument("--disable-notifications");


            driver = new EdgeDriver(options);
            driver.Manage().Window.Maximize();
        }

        [Fact]
        public void Test1()
        {
            

            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            Thread.Sleep(5000);


            ///---------------------------Usuario-----------------------------///

            var User = driver.FindElement(By.Id("user-name"));
            User.SendKeys("standard_user");
            Thread.Sleep(2000);



            ///-------------------------Contraseña-----------------------------///

            var Pass = driver.FindElement(By.Id("password"));
            Thread.Sleep(1000);
            Pass.SendKeys("secret_sauce");




            ///---------------------------Login--------------------------------///

            var Ingreso = driver.FindElement(By.Id("login-button"));         
            Ingreso.Click();
            Thread.Sleep(1000);




            ///-------------------------Carrito----------------------------------///
            
            var Car = driver.FindElement(By.ClassName("shopping_cart_link"));
            Car.Click();
            Thread.Sleep(1000);



            ///----------------------------Menu-----------------------------------///

            var Back = driver.FindElement(By.Id("react-burger-menu-btn"));
            Back.Click();
            Thread.Sleep(1000);

            
            ///-------------------------Inventario---------------------------------///

            var Compras = driver.FindElement(By.Id("inventory_sidebar_link"));
            Thread.Sleep(1000);
            Compras.Click();




            ///-------------------------Boton Producto---------------------------------///
            
            var Producto = driver.FindElement(By.Id("add-to-cart-sauce-labs-backpack"));
            Thread.Sleep(1000);
            Producto.Click();
            Thread.Sleep(3000);




            ///-------------------------Carrito----------------------------------///
            
            var Car2 = driver.FindElement(By.ClassName("shopping_cart_link"));
            Car2.Click();
            Thread.Sleep(1000);


            ///-------------------------Compra----------------------------------///


            var Compra = driver.FindElement(By.Id("checkout"));
            Compra.Click();
            Thread.Sleep(1000);



            ///-------------------------Datos compra----------------------------------///


            var Nombre = driver.FindElement(By.Id("first-name"));
            Nombre.SendKeys("Dario");
            Thread.Sleep(2000);


            var Apellido = driver.FindElement(By.Id("last-name"));
            Apellido.SendKeys("Cano Valdegaray");
            Thread.Sleep(1000);

            var CP = driver.FindElement(By.Id("postal-code"));
            CP.SendKeys("1416");
            Thread.Sleep(1000);


            ///-------------------------Confirmar compra----------------------------------///


            var Continuar = driver.FindElement(By.Id("continue"));
            Continuar.Click();
            Thread.Sleep(1000);



            ///-------------------------Finalizar compra----------------------------------///


            var Finalizar = driver.FindElement(By.Id("finish"));
            Finalizar.Click();
            Thread.Sleep(1000);


            ///-------------------------Home----------------------------------///


            var Home = driver.FindElement(By.Id("back-to-products"));
            Home.Click();
            Thread.Sleep(1000);

            Thread.Sleep(5000);
        }


        public void Dispose()
        {
         
            driver.Quit();
        }
    }
}


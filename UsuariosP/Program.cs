using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Threading;


namespace UsuariosP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Ruta al ChromeDriver (ajusta según la ubicación de tu ejecutable)
            string chromeDriverPath = @"C:\Users\Hachi\Downloads\chromedriver-win64";

            // Inicializa el WebDriver
            IWebDriver driver = new ChromeDriver(chromeDriverPath);

            try
            {
                // 1. Ir al sitio de login
                driver.Navigate().GoToUrl("http://elitefitnesscenter.somee.com/Login.aspx");
                driver.Manage().Window.Maximize(); // Maximizar la ventana

                // 2. Ingresar las credenciales de login
                driver.FindElement(By.Id("email")).SendKeys("alexagastelum05@gmail.com");
                driver.FindElement(By.Id("pass")).SendKeys("alexa");
                driver.FindElement(By.Id("btningresar")).Click();
                Thread.Sleep(2000); // Esperar 2 segundos para cargar la página

                // 3. Ir a la página de Usuarios
                driver.Navigate().GoToUrl("http://elitefitnesscenter.somee.com/Usuarios.aspx");
                Thread.Sleep(2000); // Esperar 2 segundos para cargar la página

                // 4. Crear un nuevo usuario
                driver.FindElement(By.Id("tbNombre")).SendKeys("Estefi");
                driver.FindElement(By.Id("tbaPaterno")).SendKeys("Cazo");
                driver.FindElement(By.Id("tbaMaterno")).SendKeys("Palo");
                driver.FindElement(By.Id("tbfNac")).SendKeys("03/15/1990");
                driver.FindElement(By.Id("tbEmail")).SendKeys("EstefiCazo@gmail.com");
                driver.FindElement(By.Id("tbPassword")).SendKeys("asdf");
                driver.FindElement(By.Id("tbCelular")).SendKeys("6442457812");
                driver.FindElement(By.Id("tbPeso")).SendKeys("80");
                driver.FindElement(By.Id("tbAltura")).SendKeys("");
                driver.FindElement(By.Id("tbTipo")).SendKeys("2"); // Tipo Cliente

                // Hacer clic en el botón de "Registrar"
                driver.FindElement(By.Id("btnRegistrar")).Click();
                Thread.Sleep(2000); // Esperar 2 segundos para la acción

                // Verificar si el usuario fue creado correctamente
                bool usuarioCreado = false;
                try
                {
                    IWebElement gridView = driver.FindElement(By.Id("GridView_Usuarios"));
                    var filas = gridView.FindElements(By.TagName("tr"));
                    foreach (var fila in filas)
                    {
                        if (fila.Text.Contains("Jose Cazarez")) // Comprobar si aparece el nuevo nombre
                        {
                            usuarioCreado = true;
                            break;
                        }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Error al verificar si el usuario fue creado.");
                }

                if (usuarioCreado)
                {
                    Console.WriteLine("Usuario creado correctamente.");
                }
                else
                {
                    Console.WriteLine("No se pudo crear el usuario.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error: " + ex.Message);
            }
            finally
            {
                // Cerrar el navegador
                driver.Quit();
            }
        }
    }
}










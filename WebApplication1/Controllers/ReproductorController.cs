using Melodix;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace Jonathan_Diaz.Controllers
{
    public class ReproductorController : Controller
    {
        public async Task<IActionResult> Ver(Guid id)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7180/"); // ✅ CAMBIA por el puerto real de tu API

            var response = await client.GetAsync($"api/canciones/{id}");

            if (!response.IsSuccessStatusCode)
                return RedirectToAction("Index", "Home");

            var json = await response.Content.ReadAsStringAsync();
            var cancion = JsonSerializer.Deserialize<Cancion>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return View("Reproductor", cancion); // ✅ Vista debe llamarse Reproductor.cshtml
        }
    }
}

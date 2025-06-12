using DataAccessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KE03_INTDEV_SE_2_Base.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        public DashboardController(
            ICustomerRepository customerRepository,
            IProductRepository productRepository,
            IOrderRepository orderRepository)
        {
            _customerRepository = customerRepository;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }

        public IActionResult Index()
        {
            var totalCustomers = _customerRepository.GetAllCustomers().Count();
            var totalProducts = _productRepository.GetAllProducts().Count();
            var totalOrders = _orderRepository.GetAllOrders().Count();

            ViewBag.TotalCustomers = totalCustomers;
            ViewBag.TotalProducts = totalProducts;
            ViewBag.TotalOrders = totalOrders;

            return View();
        }
    }
}

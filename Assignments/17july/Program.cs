using System;
using System.Collections.Generic;
using ShopEaseConsoleApp.Models;
using ShopEaseConsoleApp.Repository;
using ShopEaseConsoleApp.Services;
using ShopEaseConsoleApp.Menus;

namespace ShopEaseConsoleApp
{
    internal class Program
    {
        static CustomerRepository customerRepository = new CustomerRepository();
        static ProductRepository productRepository = new ProductRepository();
        static CategoryRepository categoryRepository = new CategoryRepository();
        static CartRepository cartRepository = new CartRepository();
        static OrderRepository orderRepository = new OrderRepository();

        static AuthenticationService authenticationService = new AuthenticationService(customerRepository);
        static CustomerService customerService = new CustomerService(customerRepository);
        static ProductService productService = new ProductService(productRepository);
        static CategoryService categoryService = new CategoryService(categoryRepository);
        static CartService cartService = new CartService(cartRepository);
        static OrderService orderService = new OrderService(orderRepository);
        static PaymentService paymentService = new PaymentService();
        static InvoiceService invoiceService = new InvoiceService();
        static ReportService reportService =
            new ReportService(customerRepository, productRepository, orderRepository);

        static Customer currentCustomer = null;

        static void Main(string[] args)
        {
            while (true)
            {
                MainMenu menu = new MainMenu();
                int choice = menu.Show();

                switch (choice)
                {
                    case 1:
                        AdminLogin();
                        break;

                    case 2:
                        CustomerRegister();
                        break;

                    case 3:
                        CustomerLogin();
                        break;

                    case 4:
                        Console.WriteLine("\nThank You For Using ShopEase.");
                        return;

                    default:
                        Console.WriteLine("\nInvalid Choice.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void AdminLogin()
        {
            Console.Clear();

            Console.WriteLine("========== ADMIN LOGIN ==========\n");

            Console.Write("Username : ");
            string username = Console.ReadLine();

            Console.Write("Password : ");
            string password = Console.ReadLine();

            if (authenticationService.AdminLogin(username, password))
            {
                Console.WriteLine("\nLogin Successful.");
                Console.ReadKey();
                AdminDashboard();
            }
            else
            {
                Console.WriteLine("\nInvalid Username or Password.");
                Console.ReadKey();
            }
        }

        static void CustomerRegister()
        {
            Console.Clear();

            Customer customer = new Customer();

            Console.WriteLine("====== CUSTOMER REGISTRATION ======\n");

            Console.Write("Full Name : ");
            customer.FullName = Console.ReadLine();

            Console.Write("Email : ");
            customer.Email = Console.ReadLine();

            Console.Write("Mobile : ");
            customer.Mobile = Console.ReadLine();

            Console.Write("Address : ");
            customer.Address = Console.ReadLine();

            Console.Write("Username : ");
            customer.Username = Console.ReadLine();

            Console.Write("Password : ");
            customer.Password = Console.ReadLine();

            bool result = authenticationService.Register(customer);

            if (result)
                Console.WriteLine("\nRegistration Successful.");
            else
                Console.WriteLine("\nUsername Already Exists.");

            Console.ReadKey();
        }

        static void CustomerLogin()
        {
            Console.Clear();

            Console.WriteLine("========== CUSTOMER LOGIN ==========\n");

            Console.Write("Username : ");
            string username = Console.ReadLine();

            Console.Write("Password : ");
            string password = Console.ReadLine();

            currentCustomer = authenticationService.CustomerLogin(username, password);

            if (currentCustomer != null)
            {
                Console.WriteLine("\nLogin Successful.");
                Console.ReadKey();
                CustomerDashboard();
            }
            else
            {
                Console.WriteLine("\nInvalid Username or Password.");
                Console.ReadKey();
            }
        }

        static void AdminDashboard()
        {
            while (true)
            {
                AdminMenu menu = new AdminMenu();
                int choice = menu.Show();

                switch (choice)
                {
                    case 1:
                        ProductManagement();
                        break;

                    case 2:
                        CategoryManagement();
                        break;

                    case 3:
                        ViewCustomers();
                        break;

                    case 4:
                        Reports();
                        break;

                    case 5:
                        return;
                }
            }
        }

        static void CustomerDashboard()
        {
            while (true)
            {
                CustomerMenu menu = new CustomerMenu();
                int choice = menu.Show();

                switch (choice)
                {
                    case 1:
                        ViewProducts();
                        break;

                    case 2:
                        SearchProduct();
                        break;

                    case 3:
                        ShoppingCartMenu();
                        break;

                    case 4:
                        Checkout();
                        break;

                    case 5:
                        OrderHistory();
                        break;

                    case 6:
                        UpdateProfile();
                        break;

                    case 7:
                        ChangePassword();
                        break;

                    case 8:
                        authenticationService.Logout(currentCustomer);
                        currentCustomer = null;
                        return;
                }
            }
        }
        static void ProductManagement()
{
    while (true)
    {
        ProductMenu menu = new ProductMenu();
        int choice = menu.Show();

        switch (choice)
        {
            case 1:
                AddProduct();
                break;

            case 2:
                UpdateProduct();
                break;

            case 3:
                DeleteProduct();
                break;

            case 4:
                SearchProduct();
                break;

            case 5:
                ViewProducts();
                break;

            case 6:
                return;
        }
    }
}

static void AddProduct()
{
    Console.Clear();

    Product product = new Product();

    Console.Write("Product Id : ");
    product.ProductId = int.Parse(Console.ReadLine());

    Console.Write("Name : ");
    product.Name = Console.ReadLine();

    Console.Write("Category : ");
    product.Category = Console.ReadLine();

    Console.Write("Description : ");
    product.Description = Console.ReadLine();

    Console.Write("Price : ");
    product.Price = decimal.Parse(Console.ReadLine());

    Console.Write("Quantity : ");
    product.Quantity = int.Parse(Console.ReadLine());

    Console.Write("Brand : ");
    product.Brand = Console.ReadLine();

    Console.Write("Discount (%) : ");
    product.Discount = double.Parse(Console.ReadLine());

    Console.Write("Rating : ");
    product.Rating = double.Parse(Console.ReadLine());

    productService.AddProduct(product);

    Console.WriteLine("\nProduct Added Successfully.");
    Console.ReadKey();
}

static void UpdateProduct()
{
    Console.Clear();

    Console.Write("Enter Product Id : ");
    int id = int.Parse(Console.ReadLine());

    Product product = productService.GetProductById(id);

    if (product == null)
    {
        Console.WriteLine("\nProduct Not Found.");
        Console.ReadKey();
        return;
    }

    Console.Write("New Name : ");
    product.Name = Console.ReadLine();

    Console.Write("Category : ");
    product.Category = Console.ReadLine();

    Console.Write("Description : ");
    product.Description = Console.ReadLine();

    Console.Write("Price : ");
    product.Price = decimal.Parse(Console.ReadLine());

    Console.Write("Quantity : ");
    product.Quantity = int.Parse(Console.ReadLine());

    Console.Write("Brand : ");
    product.Brand = Console.ReadLine();

    Console.Write("Discount : ");
    product.Discount = double.Parse(Console.ReadLine());

    Console.Write("Rating : ");
    product.Rating = double.Parse(Console.ReadLine());

    productService.UpdateProduct(product);

    Console.WriteLine("\nProduct Updated Successfully.");
    Console.ReadKey();
}

static void DeleteProduct()
{
    Console.Clear();

    Console.Write("Enter Product Id : ");
    int id = int.Parse(Console.ReadLine());

    if (productService.DeleteProduct(id))
        Console.WriteLine("\nProduct Deleted Successfully.");
    else
        Console.WriteLine("\nProduct Not Found.");

    Console.ReadKey();
}

static void ViewProducts()
{
    Console.Clear();

    List<Product> products = productService.GetAllProducts();

    Console.WriteLine("---------------------------------------------------------------");
    Console.WriteLine("ID\tName\t\tPrice\tQty\tBrand");
    Console.WriteLine("---------------------------------------------------------------");

    foreach (Product product in products)
    {
        Console.WriteLine(
            product.ProductId + "\t" +
            product.Name + "\t\t" +
            product.Price + "\t" +
            product.Quantity + "\t" +
            product.Brand);
    }

    Console.ReadKey();
}

static void SearchProduct()
{
    Console.Clear();

    Console.Write("Enter Name/Brand/Category : ");
    string keyword = Console.ReadLine();

    List<Product> products = productService.SearchProduct(keyword);

    if (products.Count == 0)
    {
        Console.WriteLine("\nNo Product Found.");
    }
    else
    {
        Console.WriteLine("---------------------------------------------------------------");

        foreach (Product product in products)
        {
            Console.WriteLine(
                product.ProductId + "  " +
                product.Name + "  " +
                product.Category + "  ₹" +
                product.Price);
        }
    }

    Console.ReadKey();
}

static void CategoryManagement()
{
    while (true)
    {
        CategoryMenu menu = new CategoryMenu();

        int choice = menu.Show();

        switch (choice)
        {
            case 1:
                AddCategory();
                break;

            case 2:
                UpdateCategory();
                break;

            case 3:
                DeleteCategory();
                break;

            case 4:
                ViewCategories();
                break;

            case 5:
                return;
        }
    }
}

static void AddCategory()
{
    Console.Clear();

    Category category = new Category();

    Console.Write("Category Id : ");
    category.CategoryId = int.Parse(Console.ReadLine());

    Console.Write("Category Name : ");
    category.CategoryName = Console.ReadLine();

    Console.Write("Description : ");
    category.Description = Console.ReadLine();

    categoryService.AddCategory(category);

    Console.WriteLine("\nCategory Added Successfully.");
    Console.ReadKey();
}

static void UpdateCategory()
{
    Console.Clear();

    Console.Write("Enter Category Id : ");
    int id = int.Parse(Console.ReadLine());

    Category category = categoryService.GetCategoryById(id);

    if (category == null)
    {
        Console.WriteLine("\nCategory Not Found.");
        Console.ReadKey();
        return;
    }

    Console.Write("New Category Name : ");
    category.CategoryName = Console.ReadLine();

    Console.Write("Description : ");
    category.Description = Console.ReadLine();

    categoryService.UpdateCategory(category);

    Console.WriteLine("\nCategory Updated Successfully.");
    Console.ReadKey();
}

static void DeleteCategory()
{
    Console.Clear();

    Console.Write("Enter Category Id : ");
    int id = int.Parse(Console.ReadLine());

    if (categoryService.DeleteCategory(id))
        Console.WriteLine("\nCategory Deleted Successfully.");
    else
        Console.WriteLine("\nCategory Not Found.");

    Console.ReadKey();
}

static void ViewCategories()
{
    Console.Clear();

    List<Category> categories = categoryService.GetAllCategories();

    Console.WriteLine("------------------------------------------");
    Console.WriteLine("ID\tCategory");
    Console.WriteLine("------------------------------------------");

    foreach (Category category in categories)
    {
        Console.WriteLine(
            category.CategoryId + "\t" +
            category.CategoryName);
    }

    Console.ReadKey();
}
static void ViewCustomers()
{
    Console.Clear();

    List<Customer> customers = customerService.GetAllCustomers();

    Console.WriteLine("==============================================================");
    Console.WriteLine("ID\tName\t\tUsername\tEmail");
    Console.WriteLine("==============================================================");

    if (customers.Count == 0)
    {
        Console.WriteLine("No Customers Found.");
    }
    else
    {
        foreach (Customer customer in customers)
        {
            Console.WriteLine(
                customer.UserId + "\t" +
                customer.FullName + "\t\t" +
                customer.Username + "\t\t" +
                customer.Email);
        }
    }

    Console.ReadKey();
}

static void ShoppingCartMenu()
{
    while (true)
    {
        CartMenu menu = new CartMenu();

        int choice = menu.Show();

        switch (choice)
        {
            case 1:
                ViewCart();
                break;

            case 2:
                AddItemToCart();
                break;

            case 3:
                RemoveItemFromCart();
                break;

            case 4:
                UpdateCartQuantity();
                break;

            case 5:
                ApplyCoupon();
                break;

            case 6:
                ClearCart();
                break;

            case 7:
                ViewCartTotal();
                break;

            case 8:
                return;
        }
    }
}

static void AddItemToCart()
{
    Console.Clear();

    ViewProducts();

    Console.Clear();

    Console.Write("Enter Product Id : ");
    int productId = int.Parse(Console.ReadLine());

    Product product = productService.GetProductById(productId);

    if (product == null)
    {
        Console.WriteLine("\nProduct Not Found.");
        Console.ReadKey();
        return;
    }

    Console.Write("Enter Quantity : ");
    int quantity = int.Parse(Console.ReadLine());

    if (quantity > product.Quantity)
    {
        Console.WriteLine("\nInsufficient Stock.");
        Console.ReadKey();
        return;
    }

    cartService.AddToCart(product, quantity);

    Console.WriteLine("\nItem Added To Cart Successfully.");
    Console.ReadKey();
}

static void ViewCart()
{
    Console.Clear();

    ShoppingCart cart = cartService.GetCart();

    Console.WriteLine("====================================================================");
    Console.WriteLine("ID\tProduct\t\tQty\tPrice\tTotal");
    Console.WriteLine("====================================================================");

    if (cart.Items.Count == 0)
    {
        Console.WriteLine("Cart Is Empty.");
    }
    else
    {
        foreach (CartItem item in cart.Items)
        {
            Console.WriteLine(
                item.Product.ProductId + "\t" +
                item.Product.Name + "\t\t" +
                item.Quantity + "\t" +
                item.UnitPrice + "\t" +
                item.Total);
        }
    }

    Console.ReadKey();
}

static void RemoveItemFromCart()
{
    Console.Clear();

    ViewCart();

    Console.Clear();

    Console.Write("Enter Product Id : ");
    int id = int.Parse(Console.ReadLine());

    if (cartService.RemoveFromCart(id))
        Console.WriteLine("\nItem Removed Successfully.");
    else
        Console.WriteLine("\nProduct Not Found.");

    Console.ReadKey();
}

static void UpdateCartQuantity()
{
    Console.Clear();

    ViewCart();

    Console.Clear();

    Console.Write("Enter Product Id : ");
    int id = int.Parse(Console.ReadLine());

    Console.Write("Enter New Quantity : ");
    int quantity = int.Parse(Console.ReadLine());

    if (cartService.UpdateQuantity(id, quantity))
        Console.WriteLine("\nQuantity Updated Successfully.");
    else
        Console.WriteLine("\nProduct Not Found.");

    Console.ReadKey();
}

static void ApplyCoupon()
{
    Console.Clear();

    Console.Write("Enter Coupon Code : ");
    string coupon = Console.ReadLine();

    if (cartService.ApplyCoupon(coupon))
        Console.WriteLine("\nCoupon Applied Successfully.");
    else
        Console.WriteLine("\nInvalid Coupon.");

    Console.ReadKey();
}

static void ClearCart()
{
    Console.Clear();

    cartService.ClearCart();

    Console.WriteLine("Cart Cleared Successfully.");

    Console.ReadKey();
}

static void ViewCartTotal()
{
    Console.Clear();

    ShoppingCart cart = cartService.GetCart();

    Console.WriteLine("=======================================");
    Console.WriteLine("Cart Summary");
    Console.WriteLine("=======================================");

    Console.WriteLine("Subtotal : " + cart.SubTotal);

    Console.WriteLine("Coupon Discount : " + cart.CouponDiscount);

    Console.WriteLine("GST (18%) : " + cart.GST);

    Console.WriteLine("---------------------------------------");

    Console.WriteLine("Grand Total : " + cart.GrandTotal);

    Console.WriteLine("=======================================");

    Console.ReadKey();
}
        static void Checkout()
        {
            Console.Clear();

            ShoppingCart cart = cartService.GetCart();

            if (cart.Items.Count == 0)
            {
                Console.WriteLine("Your cart is empty.");
                Console.ReadKey();
                return;
            }

            Console.Write("Delivery Address : ");
            string address = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Select Payment Method");
            Console.WriteLine("1. Credit Card");
            Console.WriteLine("2. Debit Card");
            Console.WriteLine("3. UPI");
            Console.WriteLine("4. Cash On Delivery");

            Console.Write("Choice : ");
            int option = int.Parse(Console.ReadLine());

            Payment payment = paymentService.MakePayment(
                0,
                cart.GrandTotal,
                option);

            Order order = orderService.PlaceOrder(
                currentCustomer,
                cart,
                payment.PaymentMethod,
                payment.PaymentStatus,
                address);

            payment.OrderId = order.OrderId;

            Console.Clear();

            Console.WriteLine("=========================================");
            Console.WriteLine("Order Placed Successfully");
            Console.WriteLine("=========================================");
            Console.WriteLine("Order Id : " + order.OrderId);
            Console.WriteLine("Payment : " + payment.PaymentMethod);
            Console.WriteLine("Status : " + payment.PaymentStatus);
            Console.WriteLine("Grand Total : ₹" + order.GrandTotal);
            Console.WriteLine("=========================================");

            invoiceService.PrintInvoice(order);

            cartService.ClearCart();

            Console.ReadKey();
        }

        static void OrderHistory()
        {
            while (true)
            {
                OrderMenu menu = new OrderMenu();

                int choice = menu.Show();

                switch (choice)
                {
                    case 1:
                        ViewPreviousOrders();
                        break;

                    case 2:
                        SearchOrder();
                        break;

                    case 3:
                        CancelOrder();
                        break;

                    case 4:
                        DownloadInvoice();
                        break;

                    case 5:
                        return;
                }
            }
        }

        static void ViewPreviousOrders()
        {
            Console.Clear();

            List<Order> orders =
                orderService.GetCustomerOrders(currentCustomer.FullName);

            if (orders.Count == 0)
            {
                Console.WriteLine("No Orders Found.");
            }
            else
            {
                Console.WriteLine("==============================================================");
                Console.WriteLine("OrderId\tDate\t\tAmount\tStatus");
                Console.WriteLine("==============================================================");

                foreach (Order order in orders)
                {
                    Console.WriteLine(
                        order.OrderId + "\t" +
                        order.OrderDate.ToShortDateString() + "\t" +
                        order.GrandTotal + "\t" +
                        order.PaymentStatus);
                }
            }

            Console.ReadKey();
        }

        static void SearchOrder()
        {
            Console.Clear();

            Console.Write("Enter Order Id : ");

            int orderId = int.Parse(Console.ReadLine());

            Order order = orderService.SearchOrder(orderId);

            if (order == null)
            {
                Console.WriteLine("Order Not Found.");
            }
            else
            {
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("Order Id : " + order.OrderId);
                Console.WriteLine("Customer : " + order.CustomerName);
                Console.WriteLine("Date : " + order.OrderDate);
                Console.WriteLine("Payment : " + order.PaymentMethod);
                Console.WriteLine("Status : " + order.PaymentStatus);
                Console.WriteLine("Subtotal : ₹" + order.SubTotal);
                Console.WriteLine("Discount : ₹" + order.Discount);
                Console.WriteLine("GST : ₹" + order.GST);
                Console.WriteLine("Grand Total : ₹" + order.GrandTotal);
                Console.WriteLine("---------------------------------------");
            }

            Console.ReadKey();
        }

        static void CancelOrder()
        {
            Console.Clear();

            Console.Write("Enter Order Id : ");

            int orderId = int.Parse(Console.ReadLine());

            if (orderService.CancelOrder(orderId))
                Console.WriteLine("Order Cancelled Successfully.");
            else
                Console.WriteLine("Order Not Found.");

            Console.ReadKey();
        }
        static void DownloadInvoice()
        {
            Console.Clear();

            Console.Write("Enter Order Id : ");
            int orderId = int.Parse(Console.ReadLine());

            Order order = orderService.SearchOrder(orderId);

            if (order == null)
            {
                Console.WriteLine("Order Not Found.");
            }
            else
            {
                invoiceService.PrintInvoice(order);
            }

            Console.ReadKey();
        }

        static void UpdateProfile()
        {
            Console.Clear();

            Console.WriteLine("=========== UPDATE PROFILE ===========");

            Console.Write("Full Name : ");
            currentCustomer.FullName = Console.ReadLine();

            Console.Write("Email : ");
            currentCustomer.Email = Console.ReadLine();

            Console.Write("Mobile : ");
            currentCustomer.Mobile = Console.ReadLine();

            Console.Write("Address : ");
            currentCustomer.Address = Console.ReadLine();

            if (customerService.UpdateCustomer(currentCustomer))
                Console.WriteLine("\nProfile Updated Successfully.");
            else
                Console.WriteLine("\nFailed To Update Profile.");

            Console.ReadKey();
        }

        static void ChangePassword()
        {
            Console.Clear();

            Console.Write("Old Password : ");
            string oldPassword = Console.ReadLine();

            Console.Write("New Password : ");
            string newPassword = Console.ReadLine();

            if (authenticationService.ChangePassword(
                currentCustomer.Username,
                oldPassword,
                newPassword))
            {
                Console.WriteLine("\nPassword Changed Successfully.");
            }
            else
            {
                Console.WriteLine("\nOld Password Is Incorrect.");
            }

            Console.ReadKey();
        }

        static void Reports()
        {
            while (true)
            {
                ReportMenu menu = new ReportMenu();

                int choice = menu.Show();

                switch (choice)
                {
                    case 1:
                        Console.Clear();

                        List<Customer> customers = reportService.GetAllCustomers();

                        Console.WriteLine("============== CUSTOMERS ==============");

                        foreach (Customer customer in customers)
                        {
                            Console.WriteLine(
                                customer.UserId + "  " +
                                customer.FullName + "  " +
                                customer.Username);
                        }

                        Console.ReadKey();
                        break;

                    case 2:
                        Console.Clear();

                        List<Product> products = reportService.GetAllProducts();

                        Console.WriteLine("=============== PRODUCTS ===============");

                        foreach (Product product in products)
                        {
                            Console.WriteLine(
                                product.ProductId + "  " +
                                product.Name + "  ₹" +
                                product.Price);
                        }

                        Console.ReadKey();
                        break;

                    case 3:
                        Console.Clear();

                        List<Order> orders = reportService.GetAllOrders();

                        Console.WriteLine("================ ORDERS ================");

                        foreach (Order order in orders)
                        {
                            Console.WriteLine(
                                order.OrderId + "  " +
                                order.CustomerName + "  ₹" +
                                order.GrandTotal);
                        }

                        Console.ReadKey();
                        break;

                    case 4:
                        Console.Clear();

                        Console.WriteLine("============== SALES REPORT ==============");

                        Console.WriteLine("Total Customers : " + reportService.GetTotalCustomers());
                        Console.WriteLine("Total Products  : " + reportService.GetTotalProducts());
                        Console.WriteLine("Total Orders    : " + reportService.GetTotalOrders());
                        Console.WriteLine("Total Sales     : ₹" + reportService.GetTotalSales());

                        Console.ReadKey();
                        break;

                    case 5:
                        return;

                    default:
                        Console.WriteLine("Invalid Choice.");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
package com.example.springboot.DatabaseManagement;

import com.example.springboot.Model.Product;
import com.example.springboot.Model.User;
import com.example.springboot.Repositories.OrderItemRepository;
import com.example.springboot.Repositories.OrderRepository;
import com.example.springboot.Repositories.ProductRepository;
import com.example.springboot.Repositories.UserRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.CommandLineRunner;
import org.springframework.stereotype.Component;

import java.util.ArrayList;
import java.util.List;

@Component
public class DatabaseSeeder implements CommandLineRunner {
    private ProductRepository productRepository;
    private UserRepository userRepository;
    private OrderRepository orderRepository;
    private OrderItemRepository orderItemRepository;

    @Autowired
    public DatabaseSeeder(ProductRepository productRepository,
                          UserRepository userRepository,
                          OrderRepository orderRepository,
                          OrderItemRepository orderItemRepository){

        this.productRepository = productRepository;
        this.userRepository = userRepository;
        this.orderRepository = orderRepository;
        this.orderItemRepository = orderItemRepository;
    }

    @Override
    public void run(String... args) throws Exception {
        populateProducts();
        populateUsers();
    }

    private void populateProducts(){
        List<Product> products = new ArrayList<>();

        products.add(new Product("Dumbells", 30,"Heavyweight set of dumbells","dumbell.jpg",100));
        products.add(new Product("Fitness Band", 65, "Fitness tracker", "fitnessBand.jpg",100));
        products.add(new Product("Dumbell Set", 100, "Set of small fitness dumbells", "smallDumbells.jpg",100));
        products.add(new Product("Whey Protein", 20, "Gold standard Whey Protein, of the best quality", "protein.jpg",100));

        productRepository.saveAll(products);
    }

    private void populateUsers() {
        List<User> users = new ArrayList<>();

        users.add(new User("Admin", "FitNessAdmin@gmail.com", "admin"));

        userRepository.saveAll(users);
    }
}

package com.example.springboot.RestControllers;

import com.example.springboot.Model.Order;
import com.example.springboot.Model.OrderItem;
import com.example.springboot.Model.Product;
import com.example.springboot.Model.User;
import com.example.springboot.Repositories.OrderItemRepository;
import com.example.springboot.Repositories.OrderRepository;
import com.example.springboot.Repositories.ProductRepository;
import com.example.springboot.Repositories.UserRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.*;

@RestController
@RequestMapping(value = "/orders")
@CrossOrigin
public class OrdersController {
    @Autowired
    OrderRepository orderRepository;
    @Autowired
    UserRepository userRepository;
    @Autowired
    ProductRepository productRepository;
    @Autowired
    OrderItemRepository orderItemRepository;

    @RequestMapping(value = "/all", method = RequestMethod.GET)
    public List<Order> getOrders(){
        return orderRepository.findAll();
    }

    @RequestMapping(value = "/{username}", method = RequestMethod.GET)
    public List<Order> getOrdersForUser(@PathVariable String username){
        return orderRepository.findAllByUserUsername(username);
    }

    @RequestMapping(value = "/add", method = RequestMethod.POST)
    public List<Order> createOrder(@RequestBody Order order){
        User user = userRepository.findUserByUsername(order.getUser().getUsername());
        Set<OrderItem> orderContent = new HashSet<OrderItem>();
        String rez="";

        for (OrderItem item : order.getOrderContent()) {
            Product product;
            if((product=productRepository.findProductByName(item.getProduct().getName()))!=null){
                orderContent.add(new OrderItem(product,item.getQuantity()));
            }
            else
            {
                orderContent = null;
                break;
            }
        }

        if(user!=null && orderContent!=null){
            orderRepository.save(new Order(user, orderContent));
        }

        return orderRepository.findAll();
    }
}

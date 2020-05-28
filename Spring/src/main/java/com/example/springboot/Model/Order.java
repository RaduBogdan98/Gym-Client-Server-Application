package com.example.springboot.Model;

import org.hibernate.annotations.Cascade;

import javax.persistence.*;
import java.lang.reflect.Type;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.Set;

@Entity
@Table(name = "listed_orders")
public class Order {

    @Id
    @GeneratedValue(strategy = GenerationType.SEQUENCE)
    private long orderId;

    private String orderDate;
    private double totalPrice;

    @ManyToOne
    @JoinColumn(name = "user_id")
    private User user;

    @OneToMany(cascade = CascadeType.ALL)
    private Set<OrderItem> orderContent;

    public Order(){}

    public Order(User user, Set<OrderItem> orderContent){
        SimpleDateFormat dateFormat = new SimpleDateFormat("dd/MM/yyyy");
        orderDate = dateFormat.format(new Date()).toString();

        this.user = user;
        this.orderContent = orderContent;
        this.totalPrice = computeTotalPrice(orderContent);
    }

    public User getUser() {
        return user;
    }

    public Set<OrderItem> getOrderContent() {
        return orderContent;
    }

    public String getOrderDate() {
        return orderDate;
    }

    public double getTotalPrice() {
        return totalPrice;
    }

    private double computeTotalPrice(Set<OrderItem> orderContent){
        double sum = 0;
        for (OrderItem item : orderContent) {
            sum+=item.getProduct().getPrice()*item.getQuantity();
        }

        return sum;
    }
}

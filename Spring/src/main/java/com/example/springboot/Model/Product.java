package com.example.springboot.Model;

import org.apache.commons.io.FilenameUtils;
import org.springframework.lang.NonNull;
import org.springframework.util.ResourceUtils;

import javax.persistence.*;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.util.Base64;

@Entity
public class Product {

    @Id
    @GeneratedValue(strategy = GenerationType.SEQUENCE)
    private long id;

    @NonNull
    private String name;
    private double price;
    private int stock;

    @NonNull
    private String description;
    @NonNull
    private String image;

    public Product(){}

    public Product(String name, double price, String description, String image, int stock) {
        this.name=name;
        this.price=price;
        this.description=description;
        this.image=image;
        this.stock = stock;
    }

    public String getName() {
        return name;
    }

    public double getPrice() {
        return price;
    }

    public String getDescription() {
        return description;
    }

    public String getImage() {
        return image;
    }

    public int getStock() {
        return stock;
    }

    public void setStock(int stock) {
        this.stock = stock;
    }

    public void setPrice(double price) {
        this.price = price;
    }

    public void encodeImage()
    {
        File imageFile = null;
        try {
            imageFile = ResourceUtils.getFile("classpath:images/products/"+image);

            if(imageFile!=null){
                String imageEncoded64 = null;
                try{
                    String extension = FilenameUtils.getExtension(imageFile.getName());
                    FileInputStream stream = new FileInputStream(imageFile);
                    byte[] bytes = new byte[(int)imageFile.length()];
                    stream.read(bytes);
                    imageEncoded64 = Base64.getEncoder().encodeToString(bytes);
                    stream.close();

                    image = imageEncoded64;
                }
                catch (Exception e) { }
            }
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        }
    }
}

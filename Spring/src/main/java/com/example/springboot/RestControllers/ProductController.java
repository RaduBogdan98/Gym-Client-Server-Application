package com.example.springboot.RestControllers;

import com.example.springboot.Model.Product;
import com.example.springboot.Repositories.ProductRepository;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping(value = "/products")
@CrossOrigin
public class ProductController {
    private ProductRepository productRepository;

    public ProductController(ProductRepository repository){
        this.productRepository=repository;
    }

    @RequestMapping(value = "/all", method = RequestMethod.GET)
    public List<Product> getProducts(){
        List<Product> products = productRepository.findAll();

        for (Product p: products) {
            p.encodeImage();
        }

        return products;
    }

    @RequestMapping(value = "/update", method = RequestMethod.PUT)
    public List<Product> updateProduct(@RequestBody Product product){
        Product productToUpdate = productRepository.findProductByName(product.getName());

        productToUpdate.setStock(product.getStock());
        productToUpdate.setPrice(product.getPrice());
        productRepository.save(productToUpdate);

        return productRepository.findAll();
    }
}

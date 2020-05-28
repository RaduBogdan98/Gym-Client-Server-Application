package com.example.springboot.RestControllers;

import com.example.springboot.Model.User;
import com.example.springboot.Repositories.UserRepository;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping(value = "/users")
@CrossOrigin
public class UsersController {
    private UserRepository userRepository;

    public UsersController(UserRepository repository){
        this.userRepository =repository;
    }

    @RequestMapping(value = "/all", method = RequestMethod.GET)
    public List<User> getUsers(){
        return userRepository.findAll();
    }

    @RequestMapping(value = "/login/{username}/{password}", method = RequestMethod.GET)
    public User findUserLogin(@PathVariable String username, @PathVariable String password){
        return userRepository.findByUsernameAndPassword(username, password);
    }

    @RequestMapping(value = "/isUsername/{username}", method = RequestMethod.GET)
    public boolean usernameExists(@PathVariable String username){
        return userRepository.findUserByUsername(username) != null;
    }

    @RequestMapping(value = "/isEmail/{email}", method = RequestMethod.GET)
    public boolean userEmailExists(@PathVariable String email){
        return userRepository.findUserByEmail(email) != null;
    }

    @RequestMapping(value = "/add", method = RequestMethod.POST)
    public List<User> create(@RequestBody User user){
        userRepository.save(user);

        return userRepository.findAll();
    }
}
package com.example.rl_simulation_wep.service;

import com.example.rl_simulation_wep.config.CustomUserDetails;
import com.example.rl_simulation_wep.config.JwtTokenUtil;
import com.example.rl_simulation_wep.dto.JwtResponseDTO;
import com.example.rl_simulation_wep.dto.UserDTO;
import com.example.rl_simulation_wep.entity.User;
import com.example.rl_simulation_wep.repository.UserRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.authentication.AuthenticationManager;
import org.springframework.security.authentication.UsernamePasswordAuthenticationToken;
import org.springframework.security.core.Authentication;
import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.stereotype.Service;

@Service
public class AuthService {

    private final UserService userService;
    private final JwtTokenUtil jwtTokenUtil;
    private final AuthenticationManager authenticationManager;

    @Autowired
    private PasswordEncoder passwordEncoder;

    @Autowired
    private UserRepository userRepository;

    @Autowired
    public AuthService(UserService userService, JwtTokenUtil jwtTokenUtil, AuthenticationManager authenticationManager) {
        this.userService = userService;
        this.jwtTokenUtil = jwtTokenUtil;
        this.authenticationManager = authenticationManager;
    }

    public JwtResponseDTO login(String email, String password) {
        User user = userRepository.findByEmail(email);
        Long userId = user.getUserId();
        Authentication authentication = authenticationManager.authenticate(
                new UsernamePasswordAuthenticationToken(userId, password)
        );

        CustomUserDetails userDetails = (CustomUserDetails) authentication.getPrincipal();
        String jwt = jwtTokenUtil.generateToken(userDetails.getUserId());

        return new JwtResponseDTO(jwt);
    }

    public UserDTO createUser(UserDTO userDTO, String rawPassword) {
        User user = userService.convertToEntity(userDTO);
        user.setUserPassword(passwordEncoder.encode(rawPassword));
        userRepository.save(user);
        return userService.convertToDTO(user);
    }
}
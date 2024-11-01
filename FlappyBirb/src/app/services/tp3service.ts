import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { lastValueFrom } from 'rxjs';
import { RegisterDTO } from '../models/RegisterDTO';
import { LoginDTO } from '../models/LoginDTO';
import { Router } from '@angular/router';

const domain = "https://localhost:7053/";
@Injectable({
        providedIn:"root"
})
export class TP3Service{
        constructor(public route : Router, public http : HttpClient) { }

        async login(loginUsername: string, loginPassword: string, token: string) : Promise<void>{
                let loginDTO = new LoginDTO(loginUsername, loginPassword, token);
                let x = await lastValueFrom(this.http.post<LoginDTO>(domain + "api/Users/Login", loginDTO))
                console.log(x)
                localStorage.setItem("token", x.token)
        
              }
            
            
                async register(registerUsername: string, registerEmail: string, registerPassword: string, registerPasswordConfirm: string) : Promise<void> {
                    let registerDTO = new RegisterDTO(
                      registerUsername,
                      registerEmail,
                      registerPassword,
                      registerPasswordConfirm);
                    
                    let x = await lastValueFrom(this.http.post<RegisterDTO>(domain + "api/Users/Register", registerDTO));
                    console.log(x);                    
                    }
}
        
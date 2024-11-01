import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { lastValueFrom } from 'rxjs';
import { RegisterDTO } from '../models/RegisterDTO';
import { LoginDTO } from '../models/LoginDTO';
import { Router } from '@angular/router';
import { Score } from '../models/score';

const domain = "https://localhost:7053/";
@Injectable({
        providedIn:"root"
})
export class TP3Service{
        constructor(public http : HttpClient) { }

        async login(loginUsername: string, loginPassword: string) : Promise<void>{
                let loginDTO = new LoginDTO(loginUsername, loginPassword);
                let x = await lastValueFrom(this.http.post<any>(domain + "api/Users/Login", loginDTO))
                localStorage.setItem("token", x.token)
                console.log(x)
        
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
        async getScore() : Promise<Score[]>{
                let token = localStorage.getItem("token");
                let httpOptions = {
                        headers : new HttpHeaders({
                                'Content-Type' : 'application/json',
                                'Authorization' : 'Bearer ' + token
                        })
                };

                let x = await lastValueFrom(this.http.get<Score[]>(domain + "api/Scores/GetScores", httpOptions));
                console.log(x);
                return x;
        }
        async postScore(score: Score) : Promise<void>{
                let token = localStorage.getItem("token");
                let httpOptions = {
                        headers : new HttpHeaders({
                                'Content-Type' : 'application/json',
                                'Authorization' : 'Bearer ' + token
                        })
                };

                let x = await lastValueFrom(this.http.post<Score>(domain + "api/Scores/PostScores", score, httpOptions));
                console.log(x);

                
        }
}
        
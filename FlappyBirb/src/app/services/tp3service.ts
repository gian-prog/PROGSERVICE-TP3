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
        async getPublicScore() : Promise<Score[]>{

                let x = await lastValueFrom(this.http.get<Score[]>(domain + "api/Scores/GetPublicScores"));
                console.log(x);
                return x;
        }
        async getMyScores() : Promise<Score[]>{
                let token = localStorage.getItem("token");

                let x = await lastValueFrom(this.http.get<Score[]>(domain + "api/Scores/GetMyScores" ));
                console.log(x);
                return x;
        }
        async visibilityStat(id: Number) : Promise<void>{
                let token = localStorage.getItem("token");

                let x = await lastValueFrom(this.http.put<Score>(domain + "api/Scores/PutScores/" + id, null));
                console.log(x);
        }
        async postScore(score: Score) : Promise<void>{
                let token = localStorage.getItem("token");

                let x = await lastValueFrom(this.http.post<Score>(domain + "api/Scores/PostScores", score));
                console.log(x);
        }
}
        
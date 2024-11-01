import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { MaterialModule } from '../material.module';
import { FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { RegisterDTO } from '../models/RegisterDTO';
import { lastValueFrom } from 'rxjs';
import { LoginDTO } from '../models/LoginDTO';
import { TP3Service } from '../services/tp3service';


@Component({
  selector: 'app-login',
  standalone: true,
  imports: [MaterialModule, FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {

  hide = true;

  registerUsername : string = "";
  registerEmail : string = "";
  registerPassword : string = "";
  registerPasswordConfirm : string = "";
  token : string = ""

  loginUsername : string = "";
  loginPassword : string = "";

  constructor(public route : Router, public service: TP3Service) { }

  ngOnInit() {

  }
  
  login(){
    this.service.login(this.loginUsername, this.loginPassword, this.token)
        // Redirection si la connexion a réussi :
        //if()
        this.route.navigate(["/play"]);
  }
  register(){
  this.service.register(this.registerUsername, this.registerEmail, this.registerPassword, this.registerPasswordConfirm)
  }


}

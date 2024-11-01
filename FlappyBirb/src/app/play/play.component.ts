import { Component, OnInit } from '@angular/core';
import { Game } from './gameLogic/game';
import { MaterialModule } from '../material.module';
import { CommonModule } from '@angular/common';
import { TP3Service } from '../services/tp3service';
import { Score } from '../models/score';

@Component({
  selector: 'app-play',
  standalone: true,
  imports: [MaterialModule, CommonModule],
  templateUrl: './play.component.html',
  styleUrl: './play.component.css'
})
export class PlayComponent implements OnInit{

  game : Game | null = null;
  scoreSent : boolean = false;

  constructor(public service: TP3Service){}

  ngOnDestroy(): void {
    // Ceci est crotté mais ne le retirez pas sinon le jeu bug.
    location.reload();
  }

  ngOnInit() {
    this.game = new Game();
  }

  replay(){
    if(this.game == null) return;
    this.game.prepareGame();
    this.scoreSent = false;
  }

  async sendScore(): Promise<void>{
    if(this.scoreSent) return;
    let score : number = JSON.parse(sessionStorage.getItem("score")!);
    let time : string = JSON.stringify(sessionStorage.getItem("time")!);

    let newScore = new Score(0, null, null, time, score, true )
    this.scoreSent = true;
    this.service.postScore(newScore)
    // ██ Appeler une requête pour envoyer le score du joueur ██
    // Le score est dans sessionStorage.getItem("score")
    // Le temps est dans sessionStorage.getItem("time")
    // La date sera choisie par le serveur



  }


}

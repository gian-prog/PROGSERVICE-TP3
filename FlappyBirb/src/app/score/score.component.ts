import { Component } from '@angular/core';
import { Score } from '../models/score';
import { MaterialModule } from '../material.module';
import { CommonModule } from '@angular/common';
import { Round00Pipe } from '../pipes/round-00.pipe';
import { TP3Service } from '../services/tp3service';

@Component({
  selector: 'app-score',
  standalone: true,
  imports: [MaterialModule, CommonModule, Round00Pipe],
  templateUrl: './score.component.html',
  styleUrl: './score.component.css'
})
export class ScoreComponent {

  myScores : Score[] = [];
  publicScores : Score[] = [];
  userIsConnected : boolean = false;

  constructor(public service: TP3Service) { }

  async ngOnInit() {
    this.userIsConnected = localStorage.getItem("token") != null;
     this.publicScores = await this.service.getPublicScore();
    if(this.userIsConnected){
      this.myScores = await this.service.getMyScores();
    }
   
    

  }

  async changeScoreVisibility(score : Score){

  }

}

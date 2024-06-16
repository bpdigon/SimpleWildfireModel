import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { SimEnvironment } from '../models/SimEnvironment';
import { NgClass, NgFor, NgIf } from '@angular/common';
import { WildFireService } from '../services/wild-fire-service.service';
import { FireState } from '../enum/FireState.enum';
import { UserWeatherRequest } from '../DTOs/UserWeatherRequest';
import { LightningEvent } from '../models/LightningEvent';
import { SimulationRequest } from '../DTOs/SimulationRequest';

@Component({
  selector: 'app-simulate',
  standalone: true,
  imports: [NgIf, NgFor, NgClass],
  templateUrl: './simulate.component.html',
  styleUrl: './simulate.component.scss'
})
export class SimulateComponent implements OnInit{
  env!: SimEnvironment;
  request!: SimulationRequest;
  constructor(
    private readonly service: WildFireService,
    private change: ChangeDetectorRef){}
 
  ngOnInit(): void {
    this.env = this.service.getEnvironment();
    this.request = { Environment: this.env};
  }

  public clickTableSpace(inp: any): void{
    if(inp.FireState === 4){
      inp.FireState = 0;
    }
    else{
      inp.FireState = inp.FireState + 1;
    }
  }
  
  public getEnumFireState(fire: any): string{
    return FireState[fire];
  }

  public executeTurn(){
    console.log("executeturn");
    console.log(this.env);
    this.request.Environment = this.env;
    console.log(this.request);
    this.service.putTurn(this.request).subscribe(res =>{
      console.log(res);
      this.service.setEnvironment(res.Environment);
      this.env = this.service.getEnvironment();
      console.log(this.env);
    });
    
  }

}

import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { SimEnvironment } from '../models/SimEnvironment';
import { NgClass, NgFor, NgIf } from '@angular/common';
import { WildFireService } from '../services/wild-fire-service.service';
import { FireState } from '../enum/FireState.enum';
import { UserWeatherRequest } from '../DTOs/UserWeatherRequest';
import { LightningEvent } from '../models/LightningEvent';
import { SimulationRequest } from '../DTOs/SimulationRequest';
import { WeatherAudit } from '../models/WeatherAudit';
import { WindEvent } from '../models/WindEvent';
import { RainEvent } from '../models/RainEvent';

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
  loading: boolean = false;

  lightningEvent: Array<LightningEvent> = [];
  windEvent: Array<WindEvent> = [];
  rainFall: Array<RainEvent> = [];

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
    this.loading = true;
    console.log("executeturn");
    console.log(this.env);
    this.request.Environment = this.env;
    this.request.UserWeather = {} as UserWeatherRequest; //this.lightningEvent, this.windEvent, this.rainFall);

    console.log(this.request);
    this.service.putTurn(this.request).subscribe(res =>{
      console.log("turn request subscrition")
      // console.log(res);
      this.service.setEnvironment(res);
      this.env = this.service.getEnvironment();
      this.request.Turns = res.TurnCount;
      // console.log("env");
      // console.log(this.env);
      // console.log("request");
      // console.log(this.request);
      this.loading = false;
      this.change.detectChanges();

    });
  }

}

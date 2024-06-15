import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { SimEnvironment } from '../models/SimEnvironment';
import { NgClass, NgFor, NgIf } from '@angular/common';
import { WildFireService } from '../services/wild-fire-service.service';
import { FireState } from '../enum/FireState.enum';

@Component({
  selector: 'app-simulate',
  standalone: true,
  imports: [NgIf, NgFor, NgClass],
  templateUrl: './simulate.component.html',
  styleUrl: './simulate.component.scss'
})
export class SimulateComponent implements OnInit{
  env!: SimEnvironment;

  constructor(
    private readonly service: WildFireService,
    private change: ChangeDetectorRef){}
 
  ngOnInit(): void {
    this.env = this.service.getEnvironment();
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
    this.service.putTurn(this.env).subscribe(res =>{
      console.log(res);
      this.service.setEnvironment(res);
      this.env = this.service.getEnvironment();
      console.log(this.env);
    });
    
  }
}

import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { WildFireService } from '../services/wildfire.service';
import { SimEnvironment } from '../models/SimEnvironment';
import { Subject, takeUntil } from 'rxjs';

@Component({
  selector: 'app-generate',
  standalone: true,
  imports: [],
  templateUrl: './generate.component.html',
  styleUrl: './generate.component.scss'
})
export class GenerateComponent {
  terrainGeneratedFlag: boolean = false;
  env!: SimEnvironment;
  terrainGenerateSize!: number;
  
  private readonly unsubscribe: Subject<void> = new Subject<void>();

  constructor(
    private router: Router, 
    private readonly service: WildFireService) {}

    public simulateBtnClick(): void{
      this.router.navigateByUrl('/simulate');
    }

    public generateRandomTerrain(): void{
      this.service.putGenerateTerrain(this.terrainGenerateSize).subscribe(res =>{
          this.env = res;
          this.service.setEnvironment(res);
          this.terrainGeneratedFlag = true;
        })
      
      
      this.env = this.service.getEnvironment();
    }

}

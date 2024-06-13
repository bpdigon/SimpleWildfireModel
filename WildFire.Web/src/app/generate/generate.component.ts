import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SimEnvironment } from '../models/SimEnvironment';
import { Subject, takeUntil } from 'rxjs';
import { WildFireService } from '../services/wild-fire-service.service';
import { NgIf } from '@angular/common';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-generate',
  standalone: true,
  imports: [NgIf],
  templateUrl: './generate.component.html',
  styleUrl: './generate.component.scss'
})
export class GenerateComponent implements OnInit{
  terrainGeneratedFlag: boolean = false;
  env!: SimEnvironment;
  terrainGenerateSize!: number;

  terrainGenForm: FormControl = new FormControl();
  
  private readonly unsubscribe: Subject<void> = new Subject<void>();

  constructor(
    private router: Router, 
    private readonly service: WildFireService) {}

  ngOnInit(): void {
    this.terrainGenerateSize = 2;
    this.terrainGeneratedFlag = false;
  }

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

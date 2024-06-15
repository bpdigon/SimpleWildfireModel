import { ChangeDetectorRef, Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SimEnvironment } from '../models/SimEnvironment';
import { Subject } from 'rxjs';
import { WildFireService } from '../services/wild-fire-service.service';
import { NgClass, NgFor, NgIf } from '@angular/common';
import { FormBuilder, FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { TerrainType } from '../enum/TerrainTypes.enum';
import { FireState } from '../enum/FireState.enum';

@Component({
    selector: 'app-generate',
    standalone: true,
    templateUrl: './generate.component.html',
    styleUrl: './generate.component.scss',
    imports: [NgIf, NgFor, NgClass, FormsModule, ReactiveFormsModule]
})
export class GenerateComponent implements OnInit{
  terrainGeneratedFlag: boolean = false;
  env!: SimEnvironment;
  terrainGenerateSize!: number;

  form: FormGroup = new FormGroup({});
  
  private readonly unsubscribe: Subject<void> = new Subject<void>();

  constructor(
    private router: Router, 
    private readonly service: WildFireService,
    private change: ChangeDetectorRef,
  private fb: FormBuilder) {
    this.form = fb.group({
      'terrainGenerateSize': ['', [Validators.min(1), Validators.max(10)]]
    })
  }

  ngOnInit(): void {
    this.terrainGenerateSize = 3;
    this.terrainGeneratedFlag = false;

  }

    public simulateBtnClick(): void{
      this.service.setEnvironment(this.env);
      this.router.navigateByUrl('/simulate');
    }

    public generateRandomTerrain(): void{
      this.service.putGenerateTerrain(this.terrainGenerateSize).subscribe(res =>
      {
        console.log(res);
        this.service.setEnvironment(res);
        this.env = this.service.getEnvironment();
        console.log("returned env", this.env);
        this.terrainGeneratedFlag = true;
      }
      )
    }

    public clickTerrainSpace(inp: any):void{
      console.log("click space");
      console.log(inp);
      if(inp.TerrainType === 6){
        inp.TerrainType = 0;
      }
      else{
        inp.TerrainType = inp.TerrainType + 1;
        console.log(inp.TerrainType + 1)
      }
      inp.terrainColor = TerrainType[inp.TerrainType];
      console.log(inp);
      inp.s

    }

    public clickTableSpace(inp: any): void{
      if(inp.FireState === 4){
        inp.FireState = 0;
      }
      else{
        inp.FireState = inp.FireState + 1;
      }
    }
    
    public generateEmptyTerrain(): void{
      console.log("TO BE IMPLEMENTED");
    }

    public terrainSize(size: any){
      console.log(size);
      this.terrainGenerateSize = size;
    }

    public changeSize(inp: any){

      console.log(inp);
    }

    public getEnumFireState(fire: any): string{
      return FireState[fire];
    }

}

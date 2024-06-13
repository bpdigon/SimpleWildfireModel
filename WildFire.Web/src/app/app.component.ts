import { Component } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';
import { DisplayFireComponent } from "./display-fire/display-fire.component";
import { HttpClient } from '@angular/common/http';

@Component({
    selector: 'app-root',
    standalone: true,
    templateUrl: './app.component.html',
    styleUrl: './app.component.scss',
    imports: [RouterOutlet, DisplayFireComponent]
})
export class AppComponent {
  title = 'WildFire.Web';

  constructor(private router: Router){}
  
  public menuBtnClick(): void{
    this.router.navigateByUrl('/menu');
  }

  public homeBtnClick(): void{
    this.router.navigateByUrl('');
  }
}

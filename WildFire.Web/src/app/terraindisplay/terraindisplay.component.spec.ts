import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TerraindisplayComponent } from './terraindisplay.component';

describe('TerraindisplayComponent', () => {
  let component: TerraindisplayComponent;
  let fixture: ComponentFixture<TerraindisplayComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TerraindisplayComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TerraindisplayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

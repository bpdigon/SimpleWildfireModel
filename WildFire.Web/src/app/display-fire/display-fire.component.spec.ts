import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DisplayFireComponent } from './display-fire.component';

describe('DisplayFireComponent', () => {
  let component: DisplayFireComponent;
  let fixture: ComponentFixture<DisplayFireComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DisplayFireComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DisplayFireComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

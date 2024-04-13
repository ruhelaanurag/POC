import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BasicrouteComponent } from './basicroute.component';

describe('BasicrouteComponent', () => {
  let component: BasicrouteComponent;
  let fixture: ComponentFixture<BasicrouteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BasicrouteComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BasicrouteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

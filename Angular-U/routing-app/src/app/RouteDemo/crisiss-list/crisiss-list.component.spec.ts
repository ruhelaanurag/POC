import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CrisissListComponent } from './crisiss-list.component';

describe('CrisissListComponent', () => {
  let component: CrisissListComponent;
  let fixture: ComponentFixture<CrisissListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CrisissListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CrisissListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

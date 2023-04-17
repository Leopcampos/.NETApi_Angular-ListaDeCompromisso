import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ConsultaCompromissoComponent } from './consulta-compromisso.component';

describe('ConsultaCompromissoComponent', () => {
  let component: ConsultaCompromissoComponent;
  let fixture: ComponentFixture<ConsultaCompromissoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ConsultaCompromissoComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ConsultaCompromissoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { ShowDoctorsPipe } from './show-doctors.pipe';

describe('ShowDoctorsPipe', () => {
  it('create an instance', () => {
    const pipe = new ShowDoctorsPipe();
    expect(pipe).toBeTruthy();
  });
});

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Document = iTextSharp.text.Document;

namespace HospitalLibrary.Core.Service
{
    public class ExaminationService : IExaminationService
    {
        private readonly IExaminationRepository _examinationRepository;
        private readonly ISymptomRepository _symptomRepository;
        private readonly IMedicineRepository _medicineRepository;


        public ExaminationService(IExaminationRepository examinationRepository, ISymptomRepository symptomRepository, IMedicineRepository medicineRepository)
        {
            _examinationRepository = examinationRepository;
            _symptomRepository = symptomRepository;
            _medicineRepository = medicineRepository;
        }

        public void Create(Examination entity)
        {
            entity.Deleted = false;
            _examinationRepository.Create(entity);
        }

        public void Delete(Examination entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Examination> GetAll()
        {
            return _examinationRepository.GetAll();
        }

        public Examination GetById(int id)
        {
            return _examinationRepository.GetById(id);
        }

        public void Update(Examination entity)
        {
            throw new NotImplementedException();
        }

        public List<Symptom> GetHelpSymptoms(Examination examination)
        {
            List<Symptom> pomocniSimptomi = new List<Symptom>();
            foreach (Symptom simptom in examination.Symptoms)
            {
                Symptom pomocniSimptom = new Symptom();
                pomocniSimptom = _symptomRepository.GetById(simptom.Id);
                pomocniSimptomi.Add(pomocniSimptom);
            }
            return pomocniSimptomi;
        }

        public List<Medicine> GetHelpMedicines(Prescription prescription)
        {
            List<Medicine> pomocniLekovi = new List<Medicine>();
            foreach (Medicine medicine in prescription.Medicines)
            {
                Medicine pomocniLek = new Medicine();
                pomocniLek = _medicineRepository.GetById(medicine.Id);
                pomocniLekovi.Add(pomocniLek);
            }
            return pomocniLekovi;
        }

        public byte[] GeneratePdf(Examination examination, Boolean symptoms, Boolean report, Boolean medications)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                                
                Document document = new Document(PageSize.A4, 25, 25, 30, 30);

                PdfWriter writer = PdfWriter.GetInstance(document, ms);

                writer.Open();

                document.Open();

                Paragraph para1 = new Paragraph("Examination summary", new Font(Font.FontFamily.TIMES_ROMAN, 35, Font.BOLD));
                para1.Alignment = Element.ALIGN_CENTER;
                para1.SpacingAfter = 50;
                document.Add(para1);


                if (symptoms) {
                    document.Add(new Paragraph("Symptoms: ", new Font(Font.FontFamily.TIMES_ROMAN, 15, Font.BOLD)));
                    foreach (Symptom symptom in examination.Symptoms)
                    {
                        Console.WriteLine(symptom.Name);
                        document.Add(new Paragraph(symptom.Name, new Font(Font.FontFamily.TIMES_ROMAN, 15)));
                    }
                }

                Paragraph para3 = new Paragraph();
                para3.SpacingAfter = 15;
                document.Add(para3);

                if (report)
                {
                    document.Add(new Paragraph("Report: " , new Font(Font.FontFamily.TIMES_ROMAN, 15, Font.BOLD)));
                    document.Add(new Paragraph(examination.Report, new Font(Font.FontFamily.TIMES_ROMAN, 15)));
                }

                Paragraph para4 = new Paragraph();
                para4.SpacingAfter = 15;
                document.Add(para4);

                if (medications)
                {
                    document.Add(new Paragraph("Medicines: ", new Font(Font.FontFamily.TIMES_ROMAN, 15, Font.BOLD)));
                    foreach (Prescription prescription in examination.Prescriptions)
                    {
                        foreach (Medicine medicine in prescription.Medicines)
                        {
                            Console.WriteLine(medicine.Name);
                            document.Add(new Paragraph(medicine.Name, new Font(Font.FontFamily.TIMES_ROMAN, 15)));
                        }
                    }
                }


                document.Close();
                writer.Close();
                var constant = ms.ToArray();

                return constant;


            }
        }

    }
}

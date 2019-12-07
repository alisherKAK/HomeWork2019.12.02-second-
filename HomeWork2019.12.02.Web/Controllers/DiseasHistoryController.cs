﻿using HomeWork2019._12._02.DataAccess;
using HomeWork2019._12._02.Models;
using HomeWork2019._12._02.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeWork2019._12._02.Web.Controllers
{
    public class DiseasHistoryController : Controller
    {
        DbRepository<Disease> repositoryDisease = new DbRepository<Disease>(new HospitalContext());
        DbRepository<Patient> repositoryPatient = new DbRepository<Patient>(new HospitalContext());
        // GET: DiseasHistory
        public ActionResult LookToPatients(string data, DateTime? startDate, DateTime? endDate)
        {
            var diseases = repositoryDisease.GetAll().ToList();

            if(diseases == null)
            {
                diseases = new List<Disease>();
            }
            else if(data != null && data != "")
            {
                diseases = diseases.Where(d => d.Patient.FullName == data || d.Patient.Iin == data).ToList();
            }

            if(startDate != null && endDate != null)
            {
                diseases = diseases.Where(d => d.VisitDate >= startDate && d.VisitDate <= endDate).ToList();
            }

            return View(diseases);
        }
        public ActionResult AddNote()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNotePost(Disease disease, Doctor doctor, string PatientIin)
        {
            var patient = repositoryPatient.GetAll().ToList().Where(p => p.Iin == PatientIin).FirstOrDefault();
            repositoryPatient.Delete(patient);
            disease.Patient = patient;
            disease.Doctor = doctor;
            repositoryDisease.Add(disease);

            return RedirectToAction("LookToPatients");
        }
    }
}
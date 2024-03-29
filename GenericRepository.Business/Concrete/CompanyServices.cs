﻿using GenericRepository.Business.Abstract;
using GenericRepository.Entities.Model;
using GenericRepository.Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository.Business.Concrete
{
    public class CompanyServices : ICompanyServices
    {

        private IUnitOfWork _unitOfWork;

        public CompanyServices(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<Company> CreateCompany(Company company)
        {
            await _unitOfWork.Companies.AddAsync(company);
            return company;
        }

        public async Task DeleteCompany(Company company)
        {
            _unitOfWork.Companies.Remove(company);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Company>> GetAllCompanies()
        {

            return await _unitOfWork.Companies.GetAllAsync();

        }

        public async Task<Company> GetCompanyById(int id)
        {
            return await _unitOfWork.Companies.GetByIdAsync(id);
        }

        public async Task UpdateCompany(Company companyToBeUpdate, Company company)
        {
            companyToBeUpdate.CompanyName = company.CompanyName;
            await _unitOfWork.CommitAsync();
        }

       
    }
}

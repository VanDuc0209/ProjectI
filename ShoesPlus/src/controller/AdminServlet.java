package controller;

import java.io.IOException;
import java.sql.SQLException;

import javax.servlet.RequestDispatcher;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import model.Branch;
import model.Category;

@WebServlet(name = "ControllerServlet", 
			urlPatterns = { "/admin/manager_category",
							"/admin/manager_branch",
						   	"/admin/manager_product",
						   	"/admin/insert_category",
						   	"/admin/insert_branch",
						   	"/admin/insert_product",
						   	"/admin/CRUD",
							"/admin/update_category"})
						    
public class AdminServlet extends HttpServlet{
	@Override
	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		String userPath = request.getServletPath();
		if(userPath.equals("/admin/manager_category")) {
			RequestDispatcher rd = getServletContext().getRequestDispatcher("/admin/manager_category.jsp");
	        rd.forward(request, response);
		}
		else if(userPath.equals("/admin/manager_branch")) {
			RequestDispatcher rd = getServletContext().getRequestDispatcher("/admin/manager_branch.jsp");
	        rd.forward(request, response);
		}
		else if(userPath.equals("/admin/manager_product")) {
			RequestDispatcher rd = getServletContext().getRequestDispatcher("/admin/manager_product.jsp");
	        rd.forward(request, response);
		}
		else if(userPath.equals("/admin/insert_category")) {
			RequestDispatcher rd = getServletContext().getRequestDispatcher("/admin/insert_category.jsp");
	        rd.forward(request, response);
		}
		else if(userPath.equals("/admin/insert_branch")) {
			RequestDispatcher rd = getServletContext().getRequestDispatcher("/admin/insert_branch.jsp");
	        rd.forward(request, response);
		}
		else if(userPath.equals("/admin/insert_product")) {
			RequestDispatcher rd = getServletContext().getRequestDispatcher("/admin/insert_product.jsp");
	        rd.forward(request, response);
		}
		else if(userPath.equals("/admin/update_category")) {
			RequestDispatcher rd = getServletContext().getRequestDispatcher("/admin/update_category.jsp");
	        rd.forward(request, response);
		}
		else if(userPath.equals("/admin/CRUD")) {
	        String command = request.getParameter("command");
	        if(command.equals("deleteCategory")) {
	        	int categoryID= Integer.parseInt(request.getParameter("categoryID"));
	        	Category.deleteCategory(categoryID);
	        	response.sendRedirect("manager_category");
	        }
	        else if(command.equals("deleteBranch")) {
	        	int branchID= Integer.parseInt(request.getParameter("branchID"));
	        	Branch.deleteBranch(branchID);
	        	response.sendRedirect("manager_branch");
	        }
		}
	}
	
	@Override
	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		String userPath = request.getServletPath();
		if(userPath.equals("/admin/CRUD")) {
	        String command = request.getParameter("command");
	        if(command.equals("insertCategory")) {
	        	String categoryName = request.getParameter("categoryName");
	        	Category.insertCategory(categoryName);
	        	response.sendRedirect("manager_category");
	        }
	        else if(command.equals("updateCategory")) {
	        	int categoryID= Integer.parseInt(request.getParameter("categoryID"));
	        	String categoryName = request.getParameter("categoryName");
	        	Category.updateCategory(new Category(categoryID, categoryName));
	        	response.sendRedirect("manager_category");
	        }
	        else if(command.equals("insertBranch")) {
	        	String branchName = request.getParameter("branchName");
	        	Branch.insertBranch(branchName);
	        	response.sendRedirect("manager_branch");
	        }
	        else if(command.equals("updateBranch")) {
	        	int branchID= Integer.parseInt(request.getParameter("branchID"));
	        	String branchName = request.getParameter("branchName");
	        	Branch.updateBranch(new Branch(branchID, branchName));
	        	response.sendRedirect("manager_branch");
	        }
		}
	}
}

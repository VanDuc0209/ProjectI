<%@page import="model.Category"%>
<%@page import="java.util.ArrayList"%>

<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Quản lý danh mục</title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta http-equiv="Copyright" content="arirusmanto.com">
<meta name="description" content="Admin MOS Template">
<meta name="keywords" content="Admin Page">
<meta name="author" content="Dzewyy">
<meta name="language" content="Vietnamese">

<link rel="shortcut icon" href="stylesheet/img/devil-icon.png">
<c:set var="root" value="${pageContext.request.contextPath}"/>
<link rel="stylesheet" type="text/css" href="${root}/admin/mos-css/mos-style.css"> 
</head>
<body>
	<%;
		ArrayList<Category> list = Category.getListCategory();
	%>
	<jsp:include page="header.jsp"></jsp:include>
	
	<div id="wrapper">
		<jsp:include page="menu.jsp"></jsp:include>
		<div id="rightContent">
		<h3>Quản lý danh mục</h3>
		<a href="insert_category"> Thêm danh mục</a>
		<table class="data">
			<tr class="data">
				<th class="data" width="30px">STT</th>
				<th class="data">Mã danh mục</th>
				<th class="data">Tên danh mục</th>
				<th class="data" width="90px">Tùy chọn</th>
			</tr>
			<%
				int count = 0;
				for(Category category : list) {
					count++;
			%>
			<tr class="data">
				<td class="data" width="30px"><%=count %></td>
				<td class="data"><%=category.getCategoryID() %></td>
				<td class="data"><%=category.getCategoryName() %></td>
				<td class="data" width="90px">
				<center>
					<a href="update_category?categoryID=<%=category.getCategoryID()%>">Sửa</a>&nbsp;&nbsp; | &nbsp;&nbsp;
					<a href="CRUD?command=deleteCategory&categoryID=<%=category.getCategoryID()%>">Xóa</a>
				</center>
				</td>
			</tr>
			<%
				}
			%>
		</table>
	</div>
	<div class="clear"></div>		
		<jsp:include page="footer.jsp"></jsp:include>
	</div>
</body>
</html>
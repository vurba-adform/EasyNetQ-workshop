namespace EasyNetQ.Tests;

/// <summary>
/// Demonstrates methods with varying levels of cyclomatic complexity (CC).
/// CC is equal to the number of binary decision points in a method plus one.
/// These examples are used to test agent analysis of code complexity.
/// </summary>
public static class CyclomaticComplexityExamples
{
    // ── Level 1 ────────────────────────────────────────────────────────────────

    /// <summary>CC = 1 — no decision points; single linear path.</summary>
    public static int Add(int a, int b) => a + b;

    // ── Level 2 ────────────────────────────────────────────────────────────────

    /// <summary>CC = 2 — one if.</summary>
    public static string GetSign(int n)
    {
        if (n >= 0)
            return "non-negative";
        return "negative";
    }

    // ── Level 3 ────────────────────────────────────────────────────────────────

    /// <summary>CC = 3 — two sequential if statements.</summary>
    public static string ClassifyNumber(int n)
    {
        if (n < 0)
            return "negative";
        if (n == 0)
            return "zero";
        return "positive";
    }

    // ── Level 4 ────────────────────────────────────────────────────────────────

    /// <summary>CC = 4 — three grade-boundary checks.</summary>
    public static string GetGrade(int score)
    {
        if (score >= 90) return "A";
        if (score >= 80) return "B";
        if (score >= 70) return "C";
        return "F";
    }

    // ── Level 5 ────────────────────────────────────────────────────────────────

    /// <summary>CC = 5 — four grade-boundary checks.</summary>
    public static string GetLetterGrade(int score)
    {
        if (score >= 90) return "A";
        if (score >= 80) return "B";
        if (score >= 70) return "C";
        if (score >= 60) return "D";
        return "F";
    }

    // ── Level 6 ────────────────────────────────────────────────────────────────

    /// <summary>CC = 6 — five weight-tier checks plus a guard.</summary>
    public static double CalculateShippingCost(double weightKg)
    {
        if (weightKg <= 0)
            throw new ArgumentException("Weight must be positive", nameof(weightKg));
        if (weightKg <= 1) return 5.0;
        if (weightKg <= 5) return 10.0;
        if (weightKg <= 10) return 15.0;
        if (weightKg <= 20) return 20.0;
        return 30.0;
    }

    // ── Level 7 ────────────────────────────────────────────────────────────────

    /// <summary>CC = 7 — six day-of-week numeric checks.</summary>
    public static string GetDayName(int dayOfWeek)
    {
        if (dayOfWeek == 1) return "Monday";
        if (dayOfWeek == 2) return "Tuesday";
        if (dayOfWeek == 3) return "Wednesday";
        if (dayOfWeek == 4) return "Thursday";
        if (dayOfWeek == 5) return "Friday";
        if (dayOfWeek == 6) return "Saturday";
        return "Sunday";
    }

    // ── Level 8 ────────────────────────────────────────────────────────────────

    /// <summary>CC = 8 — seven decisions: guard + two country branches each with two inner brackets.</summary>
    public static double ComputeTax(double income, string country)
    {
        if (income <= 0) return 0;
        if (country == "US")
        {
            if (income <= 10000) return income * 0.10;
            if (income <= 50000) return income * 0.22;
            return income * 0.37;
        }
        if (country == "UK")
        {
            if (income <= 12570) return 0;
            if (income <= 50270) return income * 0.20;
            return income * 0.40;
        }
        return income * 0.15;
    }

    // ── Level 9 ────────────────────────────────────────────────────────────────

    /// <summary>CC = 9 — eight decisions: null-guard + two prefix branches with inner size checks + one more prefix.</summary>
    public static string GetProductCategory(string code)
    {
        if (string.IsNullOrEmpty(code)) return "unknown";
        if (code.StartsWith("A", StringComparison.OrdinalIgnoreCase))
        {
            if (code.Length == 3) return "Type-A Small";
            if (code.Length == 5) return "Type-A Medium";
            return "Type-A Large";
        }
        if (code.StartsWith("B", StringComparison.OrdinalIgnoreCase))
        {
            if (code.Length == 3) return "Type-B Small";
            if (code.Length == 5) return "Type-B Medium";
            return "Type-B Large";
        }
        if (code.StartsWith("C", StringComparison.OrdinalIgnoreCase)) return "Type-C";
        return "Other";
    }

    // ── Level 10 ───────────────────────────────────────────────────────────────

    /// <summary>CC = 10 — nine decisions across basic email validation rules.</summary>
    public static bool ValidateEmail(string email)
    {
        if (string.IsNullOrEmpty(email)) return false;
        if (email.Contains(' ')) return false;
        int atIndex = email.IndexOf('@');
        if (atIndex <= 0) return false;
        if (atIndex == email.Length - 1) return false;
        string local = email[..atIndex];
        string domain = email[(atIndex + 1)..];
        if (local.Length > 64) return false;
        if (domain.Length < 3) return false;
        if (!domain.Contains('.')) return false;
        int dotIndex = domain.LastIndexOf('.');
        if (dotIndex == domain.Length - 1) return false;
        return true;
    }

    // ── Level 11 ───────────────────────────────────────────────────────────────

    /// <summary>CC = 11 — ten decisions across payment-method + currency routing.</summary>
    public static string ProcessPayment(string method, double amount, bool isVerified, string currency)
    {
        if (amount <= 0) return "invalid_amount";
        if (!isVerified) return "unverified";
        if (currency == "USD")
        {
            if (method == "credit")
                return amount > 1000 ? "credit_high" : "credit_normal";
            if (method == "debit") return "debit_usd";
            if (method == "paypal") return "paypal_usd";
        }
        if (currency == "EUR")
        {
            if (method == "credit") return "credit_eur";
            if (method == "debit") return "debit_eur";
        }
        if (currency == "GBP")
        {
            if (method == "credit") return "credit_gbp";
        }
        return "unsupported";
    }

    // ── Level 12 ───────────────────────────────────────────────────────────────

    /// <summary>CC = 12 — eleven decisions for insurance premium calculation.</summary>
    public static double CalculateInsurancePremium(int age, bool isSmoker, string riskLevel, bool hasPreExisting)
    {
        if (age < 18) throw new ArgumentOutOfRangeException(nameof(age));
        double premium = 100.0;
        if (age >= 60)
            premium *= 3.0;
        else if (age >= 45)
            premium *= 2.0;
        else if (age >= 30)
            premium *= 1.5;
        if (isSmoker) premium *= 1.8;
        if (riskLevel == "high")
            premium *= 2.5;
        else if (riskLevel == "medium")
            premium *= 1.5;
        else if (riskLevel == "low")
            premium *= 1.0;
        else
            throw new ArgumentException("Unknown risk level", nameof(riskLevel));
        if (hasPreExisting) premium *= 1.3;
        return premium;
    }

    // ── Level 13 ───────────────────────────────────────────────────────────────

    /// <summary>CC = 13 — twelve decisions for delivery routing logic.</summary>
    public static string RouteDeliveryPackage(string type, string destination, double weight, bool isFragile, bool isUrgent)
    {
        if (string.IsNullOrEmpty(type)) return "invalid";
        if (weight <= 0) return "invalid_weight";
        if (destination == "international")
        {
            if (isFragile && isUrgent) return "air_express_fragile";
            if (isFragile) return "air_fragile";
            if (isUrgent) return "air_express";
            if (weight > 30) return "sea_freight";
            return "air_standard";
        }
        if (destination == "domestic")
        {
            if (isUrgent && isFragile) return "courier_express_fragile";
            if (isUrgent) return "courier_express";
            if (isFragile) return "courier_fragile";
            if (weight > 20) return "truck_freight";
            return "courier_standard";
        }
        return "unknown_destination";
    }

    // ── Level 14 ───────────────────────────────────────────────────────────────

    /// <summary>CC = 14 — thirteen decisions for credit score evaluation.</summary>
    public static string EvaluateCreditApplication(int creditScore, double income, int employmentYears, bool hasMortgage, bool hasBankruptcy)
    {
        if (hasBankruptcy) return "rejected_bankruptcy";
        if (creditScore < 300 || creditScore > 850) return "invalid_score";
        if (income <= 0) return "invalid_income";
        if (creditScore < 580) return "rejected_low_score";
        if (creditScore >= 750)
        {
            if (income >= 50000) return "excellent";
            if (income >= 25000) return "good";
            return "approved_low_income";
        }
        if (creditScore >= 670)
        {
            if (employmentYears >= 3 && income >= 40000) return "good";
            if (employmentYears >= 1) return "fair";
            return "review_required";
        }
        if (hasMortgage && employmentYears < 2) return "rejected_high_risk";
        if (employmentYears >= 5) return "conditional";
        return "rejected";
    }

    // ── Level 15 ───────────────────────────────────────────────────────────────

    /// <summary>CC = 15 — fourteen decisions for maintenance scheduling.</summary>
    public static string ScheduleMaintenanceTask(string priority, string type, bool isRecurring, string location, bool requiresPermit)
    {
        if (string.IsNullOrEmpty(priority)) return "invalid";
        if (string.IsNullOrEmpty(type)) return "invalid_type";
        if (priority == "critical")
        {
            if (requiresPermit)
                return isRecurring ? "emergency_permit_recurring" : "emergency_permit_once";
            return isRecurring ? "emergency_recurring" : "emergency_once";
        }
        if (priority == "high")
        {
            if (location == "remote")
            {
                if (requiresPermit) return "high_remote_permit";
                return isRecurring ? "high_remote_recurring" : "high_remote_once";
            }
            return requiresPermit ? "high_local_permit" : "high_local";
        }
        if (priority == "medium")
        {
            if (type == "preventive") return isRecurring ? "medium_preventive_recurring" : "medium_preventive";
            if (type == "corrective") return "medium_corrective";
            return "medium_other";
        }
        if (priority == "low")
        {
            return requiresPermit ? "low_with_permit" : "low_standard";
        }
        return "unknown_priority";
    }

    // ── Level 16 ───────────────────────────────────────────────────────────────

    /// <summary>CC = 16 — fifteen decisions for user registration validation.</summary>
    public static string ValidateUserRegistration(string username, string email, string password, int age, string country)
    {
        if (string.IsNullOrEmpty(username)) return "missing_username";
        if (username.Length < 3) return "username_too_short";
        if (username.Length > 30) return "username_too_long";
        if (string.IsNullOrEmpty(email)) return "missing_email";
        if (!email.Contains('@')) return "invalid_email";
        if (string.IsNullOrEmpty(password)) return "missing_password";
        if (password.Length < 8) return "password_too_short";
        if (!password.Any(char.IsUpper)) return "password_no_upper";
        if (!password.Any(char.IsDigit)) return "password_no_digit";
        if (age < 0) return "invalid_age";
        if (country == "US" && age < 13) return "underage_us";
        if (country == "EU" && age < 16) return "underage_eu";
        if (age < 18 && country == "default") return "underage_default";
        if (username.Contains(' ')) return "username_has_spaces";
        if (email.Length > 254) return "email_too_long";
        return "valid";
    }

    // ── Level 17 ───────────────────────────────────────────────────────────────

    /// <summary>CC = 17 — sixteen decisions for freight cost computation.</summary>
    public static double ComputeFreightCost(double weight, double volume, string destination, bool isHazardous, bool isRefrigerated, bool isExpress)
    {
        if (weight <= 0) throw new ArgumentException("Invalid weight", nameof(weight));
        if (volume <= 0) throw new ArgumentException("Invalid volume", nameof(volume));
        double baseCost = weight * 0.5 + volume * 0.3;
        if (destination == "international")
        {
            baseCost *= 3.0;
            if (isHazardous) baseCost *= 2.0;
            if (isRefrigerated) baseCost *= 1.5;
            if (isExpress) baseCost *= 2.5;
            if (weight > 500) baseCost += 500;
            else if (weight > 100) baseCost += 200;
        }
        else if (destination == "regional")
        {
            baseCost *= 1.5;
            if (isHazardous) baseCost *= 1.8;
            if (isRefrigerated) baseCost *= 1.3;
            if (isExpress) baseCost *= 1.8;
            if (weight > 200) baseCost += 150;
        }
        else
        {
            if (isHazardous) baseCost *= 1.5;
            if (isRefrigerated) baseCost *= 1.2;
            if (isExpress) baseCost *= 1.5;
        }
        return Math.Round(baseCost, 2);
    }

    // ── Level 18 ───────────────────────────────────────────────────────────────

    /// <summary>CC = 18 — seventeen decisions for loan application evaluation.</summary>
    public static string EvaluateLoanApplication(int creditScore, double income, double loanAmount, int employmentYears, bool hasCollateral, bool hasCoBorrower)
    {
        if (creditScore < 300 || creditScore > 850) return "invalid_score";
        if (income <= 0) return "invalid_income";
        if (loanAmount <= 0) return "invalid_amount";
        double ratio = loanAmount / income;
        if (creditScore >= 750)
        {
            if (ratio <= 3) return "approved_excellent";
            if (ratio <= 5 && hasCollateral) return "approved_with_collateral";
            if (ratio <= 5 && hasCoBorrower) return "approved_with_coborrower";
            if (ratio <= 4) return "approved_standard";
            return "manual_review";
        }
        if (creditScore >= 670)
        {
            if (employmentYears < 2) return "rejected_employment";
            if (ratio <= 2 && income >= 60000) return "approved";
            if (ratio <= 3 && hasCollateral && hasCoBorrower) return "approved_secured";
            if (ratio <= 2) return "approved_conditional";
            return "rejected_ratio";
        }
        if (creditScore >= 580)
        {
            if (!hasCollateral && !hasCoBorrower) return "rejected_unsecured";
            if (employmentYears >= 5 && ratio <= 1.5) return "approved_marginal";
            return "manual_review";
        }
        return "rejected_low_score";
    }

    // ── Level 19 ───────────────────────────────────────────────────────────────

    /// <summary>CC = 19 — eighteen decisions for order fulfillment workflow.</summary>
    public static string ProcessOrderFulfillment(string productType, int quantity, string warehouse, bool isBackordered, string shippingMethod, bool isGift, string paymentStatus)
    {
        if (string.IsNullOrEmpty(productType)) return "invalid_product";
        if (quantity <= 0) return "invalid_quantity";
        if (paymentStatus != "paid" && paymentStatus != "pending") return "invalid_payment_status";
        if (paymentStatus == "pending") return "awaiting_payment";
        if (isBackordered)
        {
            if (quantity > 100) return "backordered_bulk";
            return "backordered_standard";
        }
        if (productType == "digital")
        {
            if (isGift) return "digital_gift_delivery";
            return "digital_delivery";
        }
        if (productType == "physical")
        {
            if (warehouse == "primary")
            {
                if (shippingMethod == "express")
                    return isGift ? "express_gift_primary" : "express_primary";
                if (shippingMethod == "standard")
                    return isGift ? "standard_gift_primary" : "standard_primary";
                return "pickup_primary";
            }
            if (warehouse == "secondary")
            {
                if (shippingMethod == "express") return "express_secondary";
                return "standard_secondary";
            }
            return "warehouse_not_found";
        }
        if (productType == "service")
        {
            return isGift ? "service_gift_voucher" : "service_scheduled";
        }
        return "unknown_product_type";
    }

    // ── Level 20 ───────────────────────────────────────────────────────────────

    /// <summary>CC = 20 — nineteen decisions for market condition analysis.</summary>
    public static string AnalyzeMarketConditions(double price, double volume, double volatility, string trend, bool isRegulated, bool isInternational, double taxRate)
    {
        if (price <= 0) return "invalid_price";
        if (volume <= 0) return "invalid_volume";
        if (taxRate < 0 || taxRate > 1) return "invalid_tax_rate";
        if (trend == "bull")
        {
            if (volatility < 0.1)
            {
                if (isInternational && isRegulated) return "bull_stable_intl_regulated";
                if (isInternational) return "bull_stable_intl";
                if (isRegulated) return "bull_stable_regulated";
                return "bull_stable";
            }
            if (volatility < 0.3)
            {
                if (volume > 1000000) return "bull_moderate_high_volume";
                return "bull_moderate";
            }
            return "bull_volatile";
        }
        if (trend == "bear")
        {
            if (volatility > 0.5) return "bear_extreme_volatile";
            if (volatility > 0.3)
                return isRegulated ? "bear_high_volatile_regulated" : "bear_high_volatile";
            if (volume < 10000) return "bear_low_volume";
            return "bear_stable";
        }
        if (trend == "sideways")
        {
            if (taxRate > 0.3) return "sideways_high_tax";
            return "sideways_normal";
        }
        return "unknown_trend";
    }

    // ── Level 21 ───────────────────────────────────────────────────────────────

    /// <summary>CC = 21 — twenty decisions for complex business rule validation.</summary>
    public static string ValidateComplexBusinessRule(string entityType, string status, double value, string region, bool isException, bool requiresApproval, bool isHighPriority, string category)
    {
        if (string.IsNullOrEmpty(entityType)) return "invalid_entity";
        if (string.IsNullOrEmpty(status)) return "invalid_status";
        if (value < 0) return "invalid_value";
        if (isException)
        {
            if (!requiresApproval) return "exception_auto_approved";
            if (isHighPriority) return "exception_priority_review";
            return "exception_standard_review";
        }
        if (entityType == "contract")
        {
            if (status == "active")
            {
                if (value > 1000000)
                    return region == "EU" ? "contract_high_value_eu" : "contract_high_value";
                if (value > 100000)
                    return requiresApproval ? "contract_medium_pending" : "contract_medium_approved";
                return "contract_low_value";
            }
            if (status == "expired") return "contract_expired";
            if (status == "draft")
                return requiresApproval ? "contract_draft_pending" : "contract_draft_ready";
        }
        if (entityType == "invoice")
        {
            if (status == "overdue")
            {
                if (value > 50000 && isHighPriority) return "invoice_critical_overdue";
                return "invoice_overdue";
            }
            if (status == "paid") return category == "service" ? "invoice_service_paid" : "invoice_paid";
            if (status == "pending") return "invoice_pending";
        }
        if (entityType == "order")
        {
            if (status == "cancelled" && value > 0) return "order_refund_required";
            return "order_processed";
        }
        return "unrecognised_entity";
    }

    // ── Level 22 ───────────────────────────────────────────────────────────────

    /// <summary>CC = 22 — twenty-one decisions for complex workflow event processing.</summary>
    public static string ProcessComplexWorkflowEvent(string eventType, string source, string target, double payload, bool isRetry, bool requiresAck, bool hasTimeout, string priority, bool isEncrypted)
    {
        if (string.IsNullOrEmpty(eventType)) return "invalid_event";
        if (string.IsNullOrEmpty(source)) return "invalid_source";
        if (string.IsNullOrEmpty(target)) return "invalid_target";
        if (payload < 0) return "invalid_payload";
        if (isRetry && priority == "low") return "retry_skipped";
        if (eventType == "message")
        {
            if (isEncrypted)
            {
                if (requiresAck && hasTimeout) return "message_encrypted_ack_timeout";
                if (requiresAck) return "message_encrypted_ack";
                return "message_encrypted_no_ack";
            }
            if (requiresAck)
            {
                if (priority == "high") return "message_high_priority_ack";
                if (priority == "medium") return "message_medium_priority_ack";
                return "message_low_priority_ack";
            }
            return hasTimeout ? "message_timeout" : "message_fire_forget";
        }
        if (eventType == "command")
        {
            if (isRetry)
            {
                if (payload > 1000) return "command_retry_large";
                return "command_retry_small";
            }
            if (target == "external")
                return isEncrypted ? "command_external_encrypted" : "command_external_plain";
            return "command_internal";
        }
        if (eventType == "query")
        {
            if (source == target) return "query_self";
            return requiresAck ? "query_with_ack" : "query_no_ack";
        }
        if (eventType == "event")
        {
            return priority == "high" ? "broadcast_high" : "broadcast_normal";
        }
        return "unknown_event_type";
    }
}

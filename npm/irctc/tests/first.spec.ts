import { test, expect } from '@playwright/test';

test('has title', async ({ page }) => {
  await page.goto('https://www.irctc.co.in/nget/train-search');

  // Expect a title "to contain" a substring.
  await expect(page).toHaveTitle(/Playwright/);
});

test('get started link', async ({ page }) => {
//   await page.goto('https://www.irctc.co.in/nget/train-search');

  await page.goto('https://www.irctc.co.in/nget/train-search',{waitUntil:"networkidle"});
  
  await page.getByRole('button', { name: 'Confirmation. Starting July 1' }).click();
  await page.goto('https://www.irctc.co.in/nget/train-search');
  await page.getByRole('button', { name: 'Confirmation. Starting July 1' }).click();
  await page.getByLabel('Enter From station. Input is').getByRole('searchbox').click();
  await page.getByLabel('Enter From station. Input is').getByRole('searchbox').fill('ndls');
  await page.getByText('(NEW DELHI)').click();
  await page.getByLabel('Enter To station. Input is').getByRole('searchbox').click();
  await page.getByLabel('Enter To station. Input is').getByRole('searchbox').fill('knw');
  await page.getByRole('option', { name: 'KHANDWA - KNW MADHYA PRADESH' }).click();
  await page.getByRole('textbox').click();
  await page.getByText('31', { exact: true }).click();
  await page.locator('div').filter({ hasText: /^GENERAL$/ }).nth(3).click();
  await page.getByRole('listbox', { name: 'GENERAL' }).press('F15');
  await page.locator('#journeyQuota').getByRole('button', { name: '' }).click();
  await page.locator('#journeyQuota').getByRole('button', { name: '' }).click();
  await page.getByText('TATKAL', { exact: true }).click();
  await page.getByRole('button', { name: 'Search' }).click();
  await page.getByLabel('10. Result for and displayed').press('F15');
});